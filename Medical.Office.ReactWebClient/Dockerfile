# Etapa 1: Build de Next.js
FROM node:lts-alpine AS build
WORKDIR /usr/src/app

# Copiar archivos de dependencias
COPY package*.json ./

# Instalar dependencias de forma limpia
RUN npm ci

# Copiar el resto del código fuente
COPY . .

# Variable para el build de Next.js (por ejemplo API URL)
ARG NEXT_PUBLIC_API_URL
ENV NEXT_PUBLIC_API_URL=$NEXT_PUBLIC_API_URL

# Ejecutar el build estático de Next.js
RUN npm run build

# Etapa 2: Imagen de producción usando Nginx
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Copiar los archivos generados por Next.js
COPY --from=build /usr/src/app/out .

# Remover configuración por defecto de Nginx
RUN rm /etc/nginx/conf.d/default.conf

# Agregar configuración personalizada de Nginx
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Exponer el puerto para servir el frontend
EXPOSE 80

# Iniciar Nginx en modo foreground
CMD ["nginx", "-g", "daemon off;"]
