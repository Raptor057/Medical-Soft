@echo off
cd /d "%~dp0"
echo.
echo Iniciando Medical Office con Docker...
docker compose up -d --build
pause
