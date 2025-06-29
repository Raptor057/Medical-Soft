@echo off
cd /d "%~dp0"
echo.
echo Borrando Medical-Soft con Docker...
docker compose down
pause
