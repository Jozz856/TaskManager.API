# Task Manager

Aplicación web para la administración y seguimiento de tareas mediante una arquitectura cliente-servidor.

El sistema permite gestionar tareas, administrar usuarios y consultar un historial de movimientos realizados sobre cada operación, implementando autenticación segura, persistencia de datos y despliegue mediante contenedores.

Desarrollado utilizando:

* ASP.NET Core Web API (.NET 8)
* React
* Entity Framework Core
* SQL Server
* JWT Authentication
* Docker
* GitHub Actions (CI/CD)

---

# Arquitectura

El proyecto implementa una arquitectura separada por capas, permitiendo mantener responsabilidades independientes, facilitar mantenimiento y aplicar buenas prácticas de desarrollo.

---

# Backend

Tecnología:

* ASP.NET Core Web API (.NET 8)

Arquitectura utilizada:

* Controllers
* Services
* Repositories
* DTOs
* Models
* Data (DbContext)

Beneficios:

* Separación de responsabilidades.
* Código mantenible y escalable.
* Facilidad para realizar pruebas y modificaciones.
* Aplicación de principios SOLID.

---

# Frontend

Aplicación desarrollada en React organizada mediante:

* Components
* Pages
* Services API
* Routing
* CSS

Implementa consumo de servicios mediante Axios y navegación utilizando React Router.

---

# Tecnologías utilizadas

## Backend

* ASP.NET Core Web API (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* JWT Authentication
* Swagger / OpenAPI

## Frontend

* React
* JavaScript
* Axios
* React Router
* CSS
* Vite

## DevOps

* Git
* GitHub
* GitHub Actions
* Docker

---

# Funcionalidades

## Autenticación

El sistema implementa autenticación mediante JSON Web Token (JWT).

Características:

* Inicio de sesión.
* Generación de token JWT.
* Validación de usuario.
* Protección de endpoints mediante autorización.
* Manejo de sesión utilizando Local Storage.

---

# Gestión de tareas

Permite realizar:

* Crear tareas.
* Consultar tareas.
* Editar tareas.
* Eliminar tareas.
* Filtrar por estado.
* Filtrar por prioridad.

Información almacenada:

* Título.
* Descripción.
* Estado.
* Prioridad.
* Fecha de creación.
* Fecha de actualización.

---

# Administración de usuarios

Incluye un módulo para gestión de usuarios:

* Registro de usuarios.
* Edición de información.
* Eliminación.
* Consulta de usuarios registrados.

---

# Historial de movimientos

La aplicación cuenta con un módulo de auditoría que registra automáticamente las acciones realizadas sobre las tareas.

Acciones registradas:

* Creación.
* Actualización.
* Eliminación.

Cada registro almacena:

* Usuario responsable.
* Fecha.
* Acción realizada.
* Tarea relacionada.
* Descripción del movimiento.

---

# Base de datos

Motor utilizado:

```
SQL Server
```

Tablas principales:

* Usuarios.
* Tareas.
* CatEstados.
* CatPrioridades.
* LogTareas.

El acceso a datos se realiza mediante Entity Framework Core.

---

# Documentación API

La API cuenta con documentación mediante Swagger / OpenAPI.

Disponible en:

```
http://localhost:8080/swagger
```

---

# Ejecución Backend

Ingresar a la carpeta:

```
TaskManager.API
```

Restaurar dependencias:

```bash
dotnet restore
```

Ejecutar aplicación:

```bash
dotnet run
```

---

# Ejecución Frontend

Ingresar al proyecto React.

Instalar dependencias:

```bash
npm install
```

Ejecutar aplicación:

```bash
npm run dev
```

Aplicación disponible en:

```
http://localhost:5174
```

---

# Docker

La API Backend cuenta con soporte mediante Docker para facilitar la ejecución del ambiente.

## Construcción de imagen

```bash
docker build -t taskmanager-api .
```

## Creación del contenedor

```bash
docker run -d -p 8080:8080 --name taskmanager-api-container taskmanager-api
```

## Validar contenedor activo

```bash
docker ps
```

## Detener contenedor

```bash
docker stop taskmanager-api-container
```

---

# Integración Continua (CI/CD)

El proyecto cuenta con integración continua mediante GitHub Actions.

Los workflows permiten validar automáticamente los cambios realizados sobre la rama principal antes de integrar nuevas modificaciones.

---

# Frontend CI

Workflow:

```
.github/workflows/frontend-ci.yml
```

Proceso ejecutado:

```
Checkout del código
        ↓
Configuración Node.js
        ↓
Instalación de dependencias
        ↓
Build de aplicación React
```

Validaciones realizadas:

* Instalación correcta de paquetes.
* Compilación del proyecto React.
* Detección automática de errores de construcción.

---

# Backend CI

Workflow:

```
.github/workflows/backend-ci.yml
```

Proceso ejecutado:

```
Checkout del código
        ↓
Configuración .NET 8
        ↓
Restauración de paquetes NuGet
        ↓
Compilación en Release
```

Validaciones realizadas:

* Restauración de dependencias.
* Compilación del proyecto.
* Validación automática de cambios.

---

# Control de versiones

El proyecto utiliza Git como sistema de control de versiones.

Repositorios:

Frontend:

```
TaskManager.React
```

Backend:

```
TaskManager.API
```

Rama principal:

```
main
```

---

# Decisiones técnicas

Durante el desarrollo se implementaron las siguientes decisiones:

* Uso de DTOs para desacoplar modelos de datos.
* Arquitectura por capas para mejorar mantenibilidad.
* Entity Framework Core como ORM.
* SQL Server como motor de persistencia.
* JWT para autenticación y seguridad.
* Axios para comunicación frontend-backend.
* React basado en componentes reutilizables.
* Registro de auditoría mediante tabla de logs.
* Docker para contenerización del backend.
* GitHub Actions para integración continua.

---

# Evidencia

El proyecto incluye:

* Código fuente.
* Script de base de datos SQL Server.
* Configuración Docker.
* Workflows CI/CD.
* Video demostrativo.

---

# Autor

**Jocelyn Andrade**

Ejercicio técnico desarrollado para proceso de selección.
