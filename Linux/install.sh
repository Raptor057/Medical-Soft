#!/bin/bash

echo "== 🐧 Instalador MedicalSoft para Linux =="

# Directorio base
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Crear archivo .env
echo "Generando archivo .env..."
cat > "$BASE_DIR/.env" <<EOF
SA_PASSWORD=Cbmwjmkq23$
EOF

# Verificar que Docker esté instalado
if ! command -v docker &> /dev/null; then
  echo "❌ Docker no está instalado. Por favor instálalo antes de continuar."
  exit 1
fi

# Verificar que docker-compose esté instalado
if ! command -v docker-compose &> /dev/null; then
  echo "❌ docker-compose no está instalado. Por favor instálalo antes de continuar."
  exit 1
fi

# Levantar contenedores
echo "Levantando infraestructura con Docker Compose..."
docker-compose -f "$BASE_DIR/docker-compose.yml" up -d

echo "✅ Instalación completada. El sistema está corriendo."
