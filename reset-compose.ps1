# PowerShell скрипт для остановки, очистки и запуска Docker Compose

Write-Host "=== Docker Compose Reset Script ===" -ForegroundColor Cyan
Write-Host ""

# Остановка и удаление контейнеров
Write-Host "1. Остановка контейнеров..." -ForegroundColor Yellow
docker compose down

Write-Host ""
Write-Host "2. Очистка неиспользуемых ресурсов..." -ForegroundColor Yellow
docker system prune -f

Write-Host ""
Write-Host "3. Запуск контейнеров..." -ForegroundColor Yellow
docker compose up -d

Write-Host ""
Write-Host "=== Готово ===" -ForegroundColor Green
Write-Host ""
docker ps -a
