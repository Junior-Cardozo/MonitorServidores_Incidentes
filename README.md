# MonitorServidores - API de Incidentes

Proyecto individual para la gestión de incidentes detectados en servidores.

## Integrante y tabla

- Integrante: TU NOMBRE COMPLETO
- Tabla: `incidentes`
- Controlador: `IncidentesController`
- Operaciones: POST, GET (todos), GET por ID, PUT y DELETE.

## Estructura

```text
MonitorServidores_Incidentes/
├── MonitorServidoresApi/
│   ├── Controllers/
│   │   └── IncidentesController.cs
│   ├── Data/
│   │   └── IncidentesDbContext.cs
│   ├── Models/
│   │   └── Incidente.cs
│   ├── Dockerfile
│   └── MonitorServidoresApi.csproj
├── contructor.yml
├── despliegue.yml
├── .env.example
├── .gitignore
└── README.md
```

## Tabla incidentes

- `id`: identificador del incidente.
- `servidor_id`: identificador del servidor relacionado.
- `titulo`: título breve.
- `descripcion`: detalle opcional.
- `gravedad`: baja, media o alta.
- `estado`: abierto, en_proceso o resuelto.
- `fecha_registro`: fecha y hora de registro.

En esta entrega individual, `servidor_id` se guarda como identificador entero. No se crea una clave foránea porque la tabla `servidores` pertenece al trabajo de otro integrante y no está incluida en esta base de datos independiente.

## Requisitos

- .NET 10 SDK
- Docker y Docker Compose
- Cuenta de Docker Hub
- Git

## Preparación

1. Copiar `.env.example` con el nombre `.env`.
2. Editar `.env` y cambiar la contraseña y el usuario de Docker Hub.
3. Desde la carpeta raíz, ejecutar:

```bash
docker compose --env-file .env -f contructor.yml up --build -d
```

## Crear la migración

Primero, crear el archivo `.env` desde `.env.example` y levantar PostgreSQL:

```bash
docker compose --env-file .env -f contructor.yml up -d postgres
```

Instalar EF Core Tools (solo la primera vez) y crear la migración:

```bash
dotnet tool install --global dotnet-ef
cd MonitorServidoresApi
ConnectionStrings__DefaultConnection="Host=localhost;Port=5435;Database=monitor_incidentes;Username=admin_incidentes;Password=CambiaEstaClave123" dotnet ef migrations add CrearTablaIncidentes
cd ..
```

Usa en ese comando los mismos valores que colocaste en tu `.env`. La API ejecuta `Database.Migrate()` al iniciar, por lo que aplicará la migración automáticamente cuando se levante el contenedor:

```bash
docker compose --env-file .env -f contructor.yml up --build -d
```

## Probar la API

Swagger:

```text
http://localhost:5080/swagger
```

Endpoints:

- `GET /api/incidentes`
- `GET /api/incidentes/{id}`
- `POST /api/incidentes`
- `PUT /api/incidentes/{id}`
- `DELETE /api/incidentes/{id}`

Ejemplo para POST:

```json
{
  "servidorId": 1,
  "titulo": "Uso elevado de CPU",
  "descripcion": "El servidor superó el umbral configurado.",
  "gravedad": "alta",
  "estado": "abierto"
}
```

## Publicar en Docker Hub

Cambiar `TU_USUARIO_DOCKERHUB` por tu usuario real y ejecutar:

```bash
docker build -t TU_USUARIO_DOCKERHUB/monitorservidores-incidentes:1.0 ./MonitorServidoresApi
docker login
docker push TU_USUARIO_DOCKERHUB/monitorservidores-incidentes:1.0
```

## Despliegue desde Docker Hub

Con `.env` configurado y la imagen publicada:

```bash
docker compose --env-file .env -f despliegue.yml pull
docker compose --env-file .env -f despliegue.yml up -d
```

## Detener los contenedores

```bash
docker compose --env-file .env -f contructor.yml down
```
