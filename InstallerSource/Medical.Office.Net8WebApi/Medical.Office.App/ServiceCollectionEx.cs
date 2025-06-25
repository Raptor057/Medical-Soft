using MediatR;
using Common.Common.CleanArch;
using Medical.Office.App.Services;
using Microsoft.Extensions.DependencyInjection;
using Medical.Office.App.Services.BackgroundService;

namespace Medical.Office.App
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            return services
                .AddHostedService<MedicalAppointmentCalendarHostedService>() //Necesario para el calendario de citas médicas
                .AddHostedService<MedicalAppointmentReminderCalendarHostedService>() //Necesario para el recordatorio de citas médicas
                .AddHttpClient() //Necesario para solicitud HTTP
                .AddHostedService<VersionCheckHostedService>() //Necesario para la verificación de versiones
                .AddTransient<EmailService>() //Necesario para el envío de correos electrónicos
                .AddTransient<EmailTemplates>() //Necesario para las plantillas de correo electrónico
                .AddTransient<WhatsAppService>() //Necesario para el envío de mensajes de WhatsApp
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(InteractorPipeline<,>)) // Necesario para el comportamiento del pipeline de MediatR
                .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionEx).Assembly); }); // Necesario para MediatR
        }
    }
}
