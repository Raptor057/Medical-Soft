#!/bin/bash

echo "🔃 Esperando a que SQL Server esté disponible..."
/opt/mssql/bin/sqlservr &

# Esperar que el puerto 1433 esté abierto
for i in {1..30}; do
  nc -z localhost 1433 && break
  echo "Esperando..."
  sleep 2
done

echo "🚀 Publicando la base de datos..."
/opt/sqlpackage/sqlpackage \
  /Action:Publish \
  /SourceFile:/publish/Medical.Office.SqlLocalDB.dacpac \
  /TargetServerName:localhost \
  /TargetDatabaseName:"Medical.Office.SqlLocalDB" \
  /TargetUser:sa \
  /TargetPassword:$MSSQL_SA_PASSWORD \
  /TargetEncryptConnection:False \
  /TargetTrustServerCertificate:True \
  /p:DropObjectsNotInSource=True \
  /p:AllowIncompatiblePlatform=True

wait
