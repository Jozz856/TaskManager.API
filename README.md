# Task Manager

Aplicación web para la administración de tareas mediante una arquitectura cliente-servidor.

El sistema permite gestionar tareas, usuarios y consultar un historial de movimientos realizados sobre cada tarea.

Desarrollado utilizando:

* ASP.NET Core Web API (.NET 8)
* React
* Entity Framework Core
* SQL Server
* JWT Authentication
* Docker

---

# Arquitectura

## Backend

Implementa una arquitectura por capas:

* Controllers
* Services
* Repositories
* DTOs
* Models
* Data (DbContext)

Permite separar responsabilidades, facilitar mantenimiento y aplicar buenas prácticas de desarrollo.

## Frontend

Aplicación desarrollada en React organizada en:

* Components
* Pages
* Services API
* Routing
* CSS

---

# Tecnologías utilizadas

## Backend

* ASP.NET Core Web API (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* JWT
* Swagger / OpenAPI

## Frontend

* React
* JavaScript
* Axios
* React Router
* CSS

---

# Funcionalidades

## Autenticación

* Inicio de sesión.
* Generación de JWT.
* Protección de endpoints mediante autorización.
* Manejo de sesión mediante Local Storage.

---

## Gestión de tareas

Permite:

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

## Administración de usuarios

Incluye:

* Registro de usuarios.
* Edición.
* Eliminación.
* Consulta de usuarios.

---

## Historial de movimientos

Cuenta con un módulo de auditoría que registra:

* Creación de tareas.
* Actualización de tareas.
* Eliminación de tareas.

Cada registro almacena:

* Usuario.
* Fecha.
* Acción realizada.
* Tarea relacionada.
* Descripción del movimiento.

---

# Base de datos

Motor utilizado:

SQL Server

Tablas principales:

* Usuarios
* Tareas
* CatEstados
* CatPrioridades
* LogTareas

---

# Documentación API

Swagger disponible en:

```
http://localhost:8080/swagger
```

---

# Ejecución Backend

Ubicarse en la carpeta:

```
TaskManager.API
```

Instalar dependencias:

```
dotnet restore
```

Ejecutar:

```
dotnet run
```

---

# Ejecución Frontend

Ingresar a la carpeta React:

Instalar dependencias:

```
npm install
```

Ejecutar:

```
npm run dev
```

Aplicación disponible en:

```
http://localhost:5174
```

---

# Docker

La API Backend cuenta con soporte mediante Docker.

Construcción de imagen:

```
docker build -t taskmanager-api .
```

Crear contenedor:

```
docker run -d -p 8080:8080 --name taskmanager-api-container taskmanager-api
```

Verificar contenedor:

```
docker ps
```

Detener:

```
docker stop taskmanager-api-container
```

---

# Decisiones técnicas

* Uso de DTOs para desacoplar modelos.
* Arquitectura por capas.
* Entity Framework Core como ORM.
* JWT para seguridad.
* Axios para consumo de API.
* React con componentes reutilizables.
* Auditoría mediante tabla de logs.

---

# Evidencia

Incluye:

* Código fuente.
* Script SQL Server.
* Video demostrativo.

---

# Autor

Jocelyn Andrade

Ejercicio técnico para proceso de selección.
