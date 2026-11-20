# Guía de contribución

Gracias por tu interés en contribuir a MonitorServidores - API de Incidentes. Esta guía describe el flujo recomendado para realizar cambios en el proyecto.

## Preparar el entorno

- Instala .NET 10 SDK, Docker, Docker Compose y Git.
- Clona el repositorio y crea `.env` copiando `.env.example`.
- Configura las variables locales necesarias en `.env`. No compartas ni subas ese archivo al repositorio.
- Consulta el [README](./README.md) para instrucciones de despliegue y uso de la API.

## Realizar cambios

1. Crea una rama para tu cambio, por ejemplo `feat/validar-incidentes` o `fix/error-al-consultar`.
2. Mantén los cambios enfocados y sigue las convenciones existentes del proyecto.
3. Si modificas el modelo o el esquema de datos, agrega la migración de Entity Framework Core correspondiente. No edites ni elimines migraciones existentes sin una razón clara.
4. No incluyas credenciales, contraseñas, archivos `.env` ni otros secretos en los cambios.

## Validar antes de compartir

Desde la carpeta del proyecto, compila la API:

```bash
dotnet build MonitorServidoresApi/MonitorServidoresApi.csproj
```

Si el cambio afecta el despliegue, revisa también la configuración de Docker Compose y prueba el flujo descrito en el README cuando sea posible.

## Compartir el cambio

- Usa un mensaje de commit breve que describa el cambio, por ejemplo: `Agrega validación al crear incidentes`.
- Antes de abrir una solicitud de cambios, revisa que incluya solo los archivos relacionados y que la compilación termine correctamente.
- En la descripción, explica qué cambiaste y cómo lo validaste. Si hay una tarea o incidencia relacionada, inclúyela.
