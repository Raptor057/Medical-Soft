/*
using Medical.Office.Net8WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del .env
DotNetEnv.Env.Load();

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["CustomLogging:SeqUri"] ?? "http://localhost:5341")
    .CreateLogger();

builder.Host.UseSerilog();

// Optimizar LOH
GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000",
            "http://MedicalOfficeWebClient:3000",
            "http://MedicalOfficeWebClient",
            "http://192.168.1.103",
            "http://77.37.74.202:3000",
            "http://192.168.100.24",
            "http://192.168.100.24:3000"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddControllers();

// Políticas de autorización personalizadas
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("All", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == ClaimTypes.Role &&
                (c.Value == "Programador" ||
                 c.Value == "Doctor" ||
                 c.Value == "Enfermera" ||
                 c.Value == "Secretaria" ||
                 c.Value == "Asistente"))));
});

// Servicios internos
builder.Services.AddServices();
builder.Services.AddSignalR();

// Autenticación JWT
var key = builder.Configuration.GetValue<string>("ApiAuthenticationSettings:SecretKey");
if (string.IsNullOrEmpty(key))
{
    throw new InvalidOperationException("Secret key is not configured. Please add 'ApiAuthenticationSettings:SecretKey' in appsettings.json or environment variables.");
}

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Medical Office ERP End Points Documentation",
        Version = "v1"
    });

    options.EnableAnnotations();
});

// Health Checks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("MedicalOfficeSqlLocalDB") ?? "MedicalOfficeSqlLocalDB", name: "sql", tags: new[] { "db", "sql" })
    .AddDiskStorageHealthCheck(options =>
    {
        options.AddDrive(Path.GetPathRoot(Environment.CurrentDirectory)!, minimumFreeMegabytes: 500);
    }, name: "disk")
    .AddProcessAllocatedMemoryHealthCheck(1024 * 1024 * 512, name: "process_allocated_memory")
    .AddWorkingSetHealthCheck(1024 * 1024 * 1024, name: "working_set")
    .AddPrivateMemoryHealthCheck(1024 * 1024 * 1024, name: "private_memory");

builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(1);
    options.AddHealthCheckEndpoint("API MedicalOffice", "http://medicalofficeapi:8080/health");
}).AddInMemoryStorage();

var app = builder.Build();

// Middleware
app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical.Office.Net8WebApi");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpMetrics(); // Prometheus

app.MapControllers();
app.MapMetrics(); // /metrics

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    AllowCachingResponses = false,
    Predicate = _ => true
});

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/monitor";
});

// Logger de errores
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    app.Run();
    logger.LogInformation("✅ Application started successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "❌ Unhandled exception occurred.");
    throw;
}
*/
using Medical.Office.Net8WebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;
using Serilog;
using System.Net;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables del .env
DotNetEnv.Env.Load();

// Configurar Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["CustomLogging:SeqUri"] ?? "http://localhost:5341")
    .CreateLogger();

builder.Host.UseSerilog();

// Optimizar LOH
GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;

// CORS Policy (Permite TODO - usar solo en entornos controlados)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .SetIsOriginAllowed(_ => true) // permite cualquier origen
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // solo si lo necesitas; requiere HTTPS y origen específico en producción
    });
});

builder.Services.AddControllers();

// Políticas de autorización personalizadas
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("All", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c => c.Type == ClaimTypes.Role &&
                (c.Value == "Programador" ||
                 c.Value == "Doctor" ||
                 c.Value == "Enfermera" ||
                 c.Value == "Secretaria" ||
                 c.Value == "Asistente"))));
});

// Servicios internos
builder.Services.AddServices();
builder.Services.AddSignalR();

// Autenticación JWT
var key = builder.Configuration.GetValue<string>("ApiAuthenticationSettings:SecretKey");
if (string.IsNullOrEmpty(key))
{
    throw new InvalidOperationException("Secret key is not configured. Please add 'ApiAuthenticationSettings:SecretKey' in appsettings.json or environment variables.");
}

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Medical Office ERP End Points Documentation",
        Version = "v1"
    });

    options.EnableAnnotations();
});

// Health Checks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("MedicalOfficeSqlLocalDB") ?? "MedicalOfficeSqlLocalDB", name: "sql", tags: new[] { "db", "sql" })
    .AddDiskStorageHealthCheck(options =>
    {
        options.AddDrive(Path.GetPathRoot(Environment.CurrentDirectory)!, minimumFreeMegabytes: 500);
    }, name: "disk")
    .AddProcessAllocatedMemoryHealthCheck(1024 * 1024 * 512, name: "process_allocated_memory")
    .AddWorkingSetHealthCheck(1024 * 1024 * 1024, name: "working_set")
    .AddPrivateMemoryHealthCheck(1024 * 1024 * 1024, name: "private_memory");

// Configuración dinámica del endpoint de HealthChecksUI
string healthCheckUrl = "http://medicalofficeapi:8080/health";
try
{
    // Extraer el host de la URL
    var host = new Uri(healthCheckUrl).Host;
    // Si no se resuelve, GetHostEntry lanzará una excepción
    Dns.GetHostEntry(host);
}
catch (SocketException)
{
    healthCheckUrl = "http://localhost:8080/health";
}
catch (Exception)
{
    healthCheckUrl = "http://localhost:8080/health";
}

builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(1);
    options.AddHealthCheckEndpoint("API MedicalOffice", healthCheckUrl);
}).AddInMemoryStorage();

var app = builder.Build();

// Middleware
app.UseCors("AllowAll");


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical.Office.Net8WebApi");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpMetrics(); // Prometheus

app.MapControllers();
app.MapMetrics(); // /metrics

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    AllowCachingResponses = false,
    Predicate = _ => true
});

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/monitor";
});

// Logger de errores
var logger = app.Services.GetRequiredService<ILogger<Program>>();

try
{
    app.Run();
    logger.LogInformation("✅ Application started successfully.");
}
catch (Exception ex)
{
    logger.LogError(ex, "❌ Unhandled exception occurred.");
    throw;
}
