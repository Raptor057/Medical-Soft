@echo off
cd /d "%~dp0"
docker compose down > nul 2>&1
exit
