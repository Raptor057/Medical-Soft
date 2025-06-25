# # Imagen base de SQL Server
# FROM mcr.microsoft.com/mssql/server:2022-latest

# # Configuración de variables de entorno
# ENV ACCEPT_EULA=Y
# ENV MSSQL_SA_PASSWORD=Cbmwjmkq23
# ENV MSSQL_PID=Express

# # Crear un volumen para la persistencia de datos
# VOLUME /var/opt/mssql

# # Health check para verificar que el servidor SQL esté listo
# HEALTHCHECK --interval=10s --timeout=10s --retries=10 \
#     CMD /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -Q "SELECT 1" || exit 1

# # Exponer el puerto predeterminado de SQL Server
# EXPOSE 1433

# # Comando para iniciar SQL Server
# CMD /opt/mssql/bin/sqlservr


FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_SA_PASSWORD=Cbmwjmkq23
ENV MSSQL_PID=Express

USER root

# Copiar zip ya descargado
#COPY sqlpackage.zip /tmp/sqlpackage.zip
COPY sqlpackage-linux-x64-en-162.5.57.1.zip /tmp/sqlpackage.zip

# Instalar dependencias y descomprimir sqlpackage
RUN apt-get update && \
    apt-get install -y unzip libunwind8 netcat && \
    #apt-get install -y unzip libunwind8 && \
    unzip /tmp/sqlpackage.zip -d /opt/sqlpackage && \
    chmod +x /opt/sqlpackage/sqlpackage && \
    ln -s /opt/sqlpackage/sqlpackage /usr/bin/sqlpackage

USER mssql

WORKDIR /publish

COPY --chmod=755 publish-db.sh .
COPY Medical.Office.SqlLocalDB.dacpac .

EXPOSE 1433

CMD ["/bin/bash", "./publish-db.sh"]
