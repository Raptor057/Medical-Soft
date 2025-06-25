# Etapa base para el contenedor final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_ENVIRONMENT=Production

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar archivos de proyecto
COPY ["Medical.Office.Net8WebApi/Medical.Office.Net8WebApi.csproj", "Medical.Office.Net8WebApi/"]
COPY ["Medical.Office.App/Medical.Office.App.csproj", "Medical.Office.App/"]
COPY ["Medical.Office.Common/Medical.Office.Common.csproj", "Medical.Office.Common/"]
COPY ["Medical.Office.Domain/Medical.Office.Domain.csproj", "Medical.Office.Domain/"]
COPY ["Medical.Office.Infra/Medical.Office.Infra.csproj", "Medical.Office.Infra/"]

# Restaurar dependencias
RUN dotnet restore "Medical.Office.Net8WebApi/Medical.Office.Net8WebApi.csproj"

# Copiar el código fuente completo
COPY . .

# Build de la solución
WORKDIR "/src/Medical.Office.Net8WebApi"
RUN dotnet build "Medical.Office.Net8WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publish + desencriptado
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG GPG_PASSPHRASE

# Instalar GPG solo en esta etapa
RUN apt-get update && apt-get install -y gnupg && rm -rf /var/lib/apt/lists/*

# Copiar archivo encriptado
COPY ["./Medical.Office.Net8WebApi/secrets/google-credentials.json.gpg", "/app/secrets/google-credentials.json.gpg"]

# Desencriptar el archivo usando la passphrase
RUN gpg --batch --yes --passphrase "$GPG_PASSPHRASE" \
    --decrypt /app/secrets/google-credentials.json.gpg \
    > /app/secrets/google-credentials.json

# Publicar la aplicación
RUN dotnet publish "Medical.Office.Net8WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final liviana
FROM base AS final
WORKDIR /app

# Copiar salida del publish (ya con secretos desencriptados)
COPY --from=publish /app/publish .

# Variables de entorno necesarias
ENV GOOGLE_APPLICATION_CREDENTIALS=/app/secrets/google-credentials.json
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Medical.Office.Net8WebApi.dll"]
