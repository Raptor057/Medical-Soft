@echo off
cd /d "%~dp0"

echo.
echo === Actualizando imágenes desde el registry (pull) ===
docker compose pull

echo.
echo === Iniciando Medical-Soft con Docker ===
docker compose up -d --build

pause
