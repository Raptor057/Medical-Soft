# 🩺 Medical Soft Installer

**Medical Soft** es un instalador todo-en-uno para un sistema médico construido en .NET 8 y React. Este paquete instala automáticamente el backend, frontend y base de datos en contenedores Docker mediante `docker-compose`, dejando el sistema listo para usarse con un solo clic.

---

## 📦 Contenido del instalador

Incluye los siguientes servicios:

- 🧠 `Medical.Office.Net8WebApi`: API REST desarrollada en .NET 8
- 🎨 `Medical.Office.ReactWebClient`: Frontend moderno con React + TailwindCSS
- 🗄️ `Medical.Office.SqlLocalDB`: Proyecto SQL Server con datos iniciales
- ⚙️ `docker-compose.yml`: Orquestador de infraestructura
- 📝 `.env`: Archivo generado dinámicamente con credenciales

---

## 🚀 Requisitos previos

Asegúrate de tener instalado:

- [Docker](https://www.docker.com/products/docker-desktop)
- Windows 10/11 (x64) **o** cualquier distribución Linux/macOS con soporte para Docker

---


## 🖥️ Instalación en Windows

1. **Descarga el instalador:**  
   Ve a la pestaña [Releases](https://github.com/Raptor057/Medical-Soft/releases) y descarga el archivo `.exe` más reciente (`MedicalSoftInstaller.exe`).

2. **Ejecuta el instalador como administrador.**

3. **Espera a que Docker levante los servicios automáticamente:**
   - Frontend: `http://localhost/`

---

## ⚠️ Notas importantes

- El archivo `.env` se genera dinámicamente durante la instalación.
- Si Docker no está instalado o no está en el `PATH`, el instalador no continuará.

---

## 🍎 Instalación en macOS

1. Descarga el archivo `installer-linux-macos.zip` desde [Releases](https://github.com/Raptor057/Medical-Soft/releases).


```bash
# Convierte a formato UNIX (LF)
sed -i '' 's/\r$//' install.sh
# Da permisos
chmod +x install.sh

# Ejecuta
./install.sh
```

## 🐧 Instalación en Linux (Ubuntu / Debian / Fedora)
1. Descarga y descomprime el archivo `installer-linux-macos.zip` desde [Releases](https://github.com/Raptor057/Medical-Soft/releases).

2. Dale permisos de ejecución y corre el instalador
```bash
unzip installer-linux-macos.zip
cd installer-linux-macos
```

2. Asigna permisos y ejecuta:

```bash
# Convierte a formato UNIX
sed -i 's/\r$//' install.sh

# Da permisos
chmod +x install.sh

# Ejecuta
./install.sh

```

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