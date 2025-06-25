
# # syntax=docker/dockerfile:1
# ARG SA_PASSWORD
# FROM mcr.microsoft.com/mssql/server:2022-latest AS final

# ENV MSSQL_SA_PASSWORD=${SA_PASSWORD}
# ENV ACCEPT_EULA=Y

# # ⚠️ Ejecutar como root para instalar paquetes
# USER root

# # Instala dependencias necesarias
# RUN apt-get update && \
#     apt-get install -y unzip libunwind8 libicu-dev netcat && \
#     rm -rf /var/lib/apt/lists/*

# # Instala sqlpackage
# COPY sqlpackage-linux-x64-en-*.zip /tmp/sqlpackage.zip
# RUN unzip /tmp/sqlpackage.zip -d /opt/sqlpackage && \
#     chmod +x /opt/sqlpackage/sqlpackage && \
#     ln -s /opt/sqlpackage/sqlpackage /usr/bin/sqlpackage

# # Script y dacpac
# WORKDIR /publish
# COPY publish-db.sh .
# COPY Medical.Office.SqlLocalDB.dacpac .
# RUN chmod +x publish-db.sh

# # Opcional: vuelve al usuario mssql si quieres que la publicación no sea como root
# # USER mssql

# CMD ["/bin/bash", "/publish/publish-db.sh"]

# syntax=docker/dockerfile:1

# syntax=docker/dockerfile:1

### ETAPA 1: Build del .dacpac ###
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS builder

WORKDIR /src

# Copia el archivo .sqlproj y restaura dependencias
COPY "./Medical.Office.SqlLocalDB.Migrated.sqlproj" "./"
RUN dotnet restore

# Copia el contenido del proyecto SQL
COPY ["./", "./"]

# Compila el .dacpac usando dotnet build
#RUN dotnet build -c Release -o /out
RUN dotnet build Medical.Office.SqlLocalDB.Migrated.sqlproj -c Release -o /out

### ETAPA 2: Publicar en SQL Server ###
ARG SA_PASSWORD
FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=${SA_PASSWORD}

USER root

# Instala dependencias necesarias
RUN apt-get update && \
    apt-get install -y unzip libunwind8 libicu-dev netcat && \
    rm -rf /var/lib/apt/lists/*

# Instala sqlpackage
COPY sqlpackage-linux-x64-en-*.zip /tmp/sqlpackage.zip
RUN unzip /tmp/sqlpackage.zip -d /opt/sqlpackage && \
    chmod +x /opt/sqlpackage/sqlpackage && \
    ln -s /opt/sqlpackage/sqlpackage /usr/bin/sqlpackage

# Directorio de trabajo para la publicación
WORKDIR /publish

# Copia el script de publicación y el .dacpac generado
COPY --from=builder /out/*.dacpac ./Medical.Office.SqlLocalDB.dacpac
#COPY Medical.Office.SqlLocalDB/publish-db.sh .
COPY ["./publish-db.sh","."]
RUN chmod +x publish-db.sh

# Ejecuta el script de publicación al arrancar el contenedor
CMD ["/bin/bash", "/publish/publish-db.sh"]
