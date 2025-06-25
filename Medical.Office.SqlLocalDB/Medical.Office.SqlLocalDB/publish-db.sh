#!/bin/bash

set -e  # Salir si hay cualquier error

# Esperar a que el contenedor SQL esté disponible
echo "⏳ Esperando a que SQL Server en 'medicalofficesql' esté listo..."
for i in {1..30}; do
  if nc -z medicalofficesql 1433; then
    echo "✅ SQL Server está disponible."
    break
  fi
  echo "⌛ Esperando..."
  sleep 10
done

if ! nc -z medicalofficesql 1433; then
  echo "❌ Error: SQL Server en 'medicalofficesql' no responde después de 60 segundos."
  exit 1
fi

echo "🚀 Publicando la base de datos con sqlpackage..."
/opt/sqlpackage/sqlpackage \
  /Action:Publish \
  /SourceFile:/publish/Medical.Office.SqlLocalDB.dacpac \
  /TargetServerName:medicalofficesql \
  /TargetDatabaseName:"Medical.Office.SqlLocalDB" \
  /TargetUser:sa \
  /TargetPassword:"${MSSQL_SA_PASSWORD}" \
  /TargetEncryptConnection:False \
  /TargetTrustServerCertificate:True \
  /p:DropObjectsNotInSource=True \
  /p:AllowIncompatiblePlatform=True

echo "🎉 ¡Publicación completada con éxito!"
