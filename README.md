# Rick and Morty Episodes API

**Prueba Técnica para Chile Autos**

Una API REST desarrollada en .NET 9 que consume la API de Rick and Morty para proporcionar endpoints de episodios con funcionalidades de filtrado y paginación.

## Descripción

Esta API permite consultar episodios de Rick and Morty con las siguientes características:

- **Listado de episodios** con paginación
- **Filtros de búsqueda** por nombre y código de episodio
- **Detalle de episodios** individuales
- **Documentación** automática con Swagger
- **Arquitectura escalable** con Clean Architecture

## Arquitectura Backend

Implementa **Clean Architecture** con 4 capas bien definidas:

```
RickAndMorty.API (Presentation Layer)
├── Controllers/
├── Middleware/
└── Program.cs

RickAndMorty.Application (Application Layer)
├── DTOs/
├── Interfaces/
└── Services/

RickAndMorty.Domain (Domain Layer)
├── Entities/
└── Interfaces/

RickAndMorty.Infrastructure (Infrastructure Layer)
├── Configuration/
└── Repositories/
```

## Frontend (Pendiente de desarrollo)

El frontend está planificado para ser desarrollado con las siguientes tecnologías:

- **Angular 19** con Standalone Components
- **TypeScript** para tipado fuerte
- **Angular Router** para navegación SPA
- **CSS3** para estilos modernos
- **Componentes modulares** reutilizables

*Estado actual: Estructura básica creada, implementación en desarrollo*

## Tecnologías Utilizadas

### Backend
- **.NET 9** - Framework principal
- **ASP.NET Core Web API** - API REST
- **HttpClient** - Consumo de APIs externas
- **Swagger/OpenAPI** - Documentación de API
- **Clean Architecture** - Patrón arquitectónico

### Frontend (Planificado)
- **Angular 19** - Framework frontend moderno
- **TypeScript** - Lenguaje tipado
- **Standalone Components** - Arquitectura sin NgModules
- **Angular Router** - Navegación SPA
- **CSS3** - Estilos modernos

### APIs Externas
- **Rick and Morty API** - Fuente de datos

## Instalación y Configuración

### Prerrequisitos
- **.NET 9 SDK**

### Backend Setup

1. **Navegar al directorio del backend:**
   ```bash
   cd PruebaTecnicaCarsales/backend
   ```

2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

3. **Ejecutar la aplicación:**
   ```bash
   dotnet run --project src/RickAndMorty.API
   ```

4. **API disponible en:**
   - API: `https://localhost:7043`
   - Swagger: `https://localhost:7043/swagger`

## API Endpoints

### Episodios

| Método | Endpoint | Descripción |
|--------|----------|-------------|
| `GET` | `/api/episodes` | Lista episodios con paginación |
| `GET` | `/api/episodes/{id}` | Detalle de un episodio específico |

### Parámetros de consulta para `/api/episodes`:
- `page` - Número de página (default: 1)
- `name` - Filtro por nombre de episodio
- `episode` - Filtro por código de episodio (ej: "S01E01")

### Ejemplos:
```bash
# Obtener episodios de la primera página
GET /api/episodes

# Filtrar episodios por nombre
GET /api/episodes?name=pilot

# Filtrar por código de episodio
GET /api/episodes?episode=S01E01

# Paginación
GET /api/episodes?page=2

# Obtener episodio específico
GET /api/episodes/1
```

## Estructura del Proyecto

```
TechnicalTestCA/
├── README.md
└── PruebaTecnicaCarsales/
    ├── backend/                       # API REST implementada
    │   ├── RickAndMorty.sln
    │   └── src/
    │       ├── RickAndMorty.API/
    │       ├── RickAndMorty.Application/
    │       ├── RickAndMorty.Domain/
    │       └── RickAndMorty.Infrastructure/
    └── frontend/                      # Pendiente de desarrollo
        └── (Estructura básica creada)
```

## Características Implementadas

### Backend (Completado)
- **Clean Architecture** con separación de capas
- **Inyección de dependencias**
- **Manejo de errores** con middleware personalizado
- **Logging** estructurado
- **Configuración** externa
- **Documentación** con Swagger
- **CORS** configurado para integración futura

### Frontend (En desarrollo)
- **En desarrollo** - Estructura básica preparada
- **Planificado:** Standalone Components, routing, servicios HTTP
- **Próximo:** Implementación de componentes y vistas

## Flujo de Datos Actual

```
Cliente HTTP Request 
    ↓ 
Backend API (.NET 9)
    ↓ Repository Pattern
Rick and Morty API
    ↓ JSON Response
Backend Processing (DTOs)
    ↓ 
JSON Response to Client
```

## Testing

### Backend
```bash
dotnet test
```

## Build para Producción

### Backend
```bash
dotnet publish -c Release
```

## Autor

**Alexey Axel** - Desarrollador Backend

---

## Notas del Desarrollo

### Backend (Completado)
- Implementación de **Clean Architecture** para mantenibilidad
- **Configuración CORS** para futura integración con frontend
- **Manejo de errores** centralizado con middleware
- **Logging** implementado para debugging y monitoreo
- **Documentación automática** con Swagger/OpenAPI

### Frontend (Pendiente)
- **Estructura base** creada con Angular 19
- **Tecnologías seleccionadas:** Angular Standalone Components
- **Estado:** Pendiente de implementación de servicios HTTP y componentes UI
- **Próximos pasos:** Desarrollo de lista de episodios, filtros y vista detalle
