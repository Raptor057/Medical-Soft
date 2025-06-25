### ETAPA 1: Build del .dacpac ###
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS builder

WORKDIR /src

# Copia el archivo .sqlproj y restaura dependencias
COPY "./Medical.Office.SqlLocalDB.Migrated.sqlproj" "./"
RUN dotnet restore

# Copia el contenido del proyecto SQL
COPY ["./", "./"]

# Compila el .dacpac usando dotnet build
RUN dotnet build Medical.Office.SqlLocalDB.Migrated.sqlproj -c Release -o /out

# Instala sqlpackage
COPY sqlpackage-linux-x64-en-*.zip /tmp/sqlpackage.zip
RUN apt-get update && \
    apt-get install -y unzip libunwind8 libicu-dev && \
    unzip /tmp/sqlpackage.zip -d /opt/sqlpackage && \
    chmod +x /opt/sqlpackage/sqlpackage && \
    ln -s /opt/sqlpackage/sqlpackage /usr/bin/sqlpackage

# Publicar directamente desde el builder (opcional)
# Puedes dejarlo comentado si prefieres que la publicación ocurra en la segunda etapa
# RUN sqlpackage /Action:Publish /SourceFile:/out/Medical.Office.SqlLocalDB.dacpac \
#     /TargetServerName:<servidor> /TargetDatabaseName:<nombreDB> \
#     /TargetUser:sa /TargetPassword:<contraseña>

### Etapa 2 - Imagen final para publicar en SQL Server ###
FROM mcr.microsoft.com/mssql/server:2022-latest

ARG SA_PASSWORD
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=${SA_PASSWORD}
ENV MSSQL_SA_PASSWORD=${SA_PASSWORD}

USER root

RUN apt-get update && \
    apt-get install -y unzip libunwind8 libicu-dev netcat && \
    rm -rf /var/lib/apt/lists/*

COPY sqlpackage-linux-x64-en-*.zip /tmp/sqlpackage.zip
RUN unzip /tmp/sqlpackage.zip -d /opt/sqlpackage && \
    chmod +x /opt/sqlpackage/sqlpackage && \
    ln -s /opt/sqlpackage/sqlpackage /usr/bin/sqlpackage

WORKDIR /publish

COPY --from=builder /out/*.dacpac ./Medical.Office.SqlLocalDB.dacpac
COPY ["./publish-db.sh","."]

# 🔧 Limpia los CRLF y da permisos de ejecución
RUN sed -i 's/\r$//' publish-db.sh && chmod +x publish-db.sh

CMD ["/bin/bash", "/publish/publish-db.sh"]
