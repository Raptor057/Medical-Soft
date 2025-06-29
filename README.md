# 🩺 Medical Soft Installer

**Medical Soft** es un instalador todo-en-uno para un sistema médico construido en .NET 8 y React. Este paquete instala automáticamente el backend, frontend y base de datos local en contenedores Docker mediante `docker-compose`, dejando el sistema listo para usarse con un solo clic.

---

## 📦 Contenido del instalador

El instalador incluye:

- `Medical.Office.Net8WebApi`: API REST desarrollada en .NET 8
- `Medical.Office.ReactWebClient`: Frontend moderno construido con React y TailwindCSS
- `Medical.Office.SqlLocalDB`: Proyecto SQL con estructura y datos iniciales
- `docker-compose.yml`: Orquestador de servicios Docker
- `start.bat`: Script para levantar la infraestructura
- `.env`: Archivo generado dinámicamente con la configuración necesaria

---

## 🚀 Requisitos

Antes de instalar, asegúrate de tener:

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado y corriendo
- Windows 10/11 (64-bit)

---

## 🛠️ Instalación

1. **Descarga el instalador:**  
   Ve a la pestaña [Releases](https://github.com/TU_REPO/releases) y descarga el archivo `.exe` más reciente (`MedicalSoftInstaller.exe`).

2. **Ejecuta el instalador como administrador.**

3. **Ingresa la IP del servidor local donde correrá el backend.**  
   Por defecto, se usará el puerto `8080`.

4. **El sistema levantará automáticamente los contenedores Docker** con:
   - API en `http://TU_IP:8080/`
   - Frontend en `http://TU_IP:3000/`

---

## ⚠️ Notas importantes

- El archivo `.env` se genera dinámicamente durante la instalación.
- Si Docker no está instalado o no está en el `PATH`, el instalador no continuará.
- El instalador evita copiar carpetas innecesarias como `bin`, `obj`, `.vs`, `node_modules`, etc.

---

## 📤 Publicación de nuevas versiones (desarrolladores)

Para generar y publicar una nueva versión del instalador en GitHub Releases, realiza lo siguiente:

1. Actualiza tu código y haz commit normalmente.
2. Crea un nuevo tag con la versión deseada:

```bash

git tag v1.2.0
git push origin v1.2.0
```

1. Borrar un tag

```bash
git tag -d v1.2.0
git push origin :refs/tags/v1.2.0
```