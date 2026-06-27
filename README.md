#  Task Manager

## Descripción

Task Manager es una aplicación web desarrollada para la administración de tareas mediante una arquitectura cliente-servidor. La solución permite crear, consultar, actualizar y eliminar tareas, así como administrar usuarios y consultar un historial de movimientos realizados sobre cada tarea.

El proyecto fue desarrollado utilizando **ASP.NET Core Web API** para el backend y **React** para el frontend, implementando autenticación mediante JWT, persistencia de datos con **Entity Framework Core** y **SQL Server** como base de datos.

---

# Arquitectura utilizada

El proyecto implementa una **Arquitectura por Capas**, separando claramente las responsabilidades de cada componente.

## Backend

* Controllers
* Services
* Repositories
* DTOs
* Models
* Data (DbContext)

Esta separación facilita el mantenimiento, reutilización del código y aplicación de principios SOLID.

## Frontend

El proyecto en React está organizado en:

* Components
* Pages
* API Services
* CSS
* Routing

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

---

# Funcionalidades implementadas

## Gestión de tareas

* Crear tarea
* Editar tarea
* Eliminar tarea
* Consultar tarea por ID
* Listar tareas
* Filtrar por Estado
* Filtrar por Prioridad

Cada tarea contiene:

* Título
* Descripción
* Estado
* Prioridad
* Fecha de creación
* Fecha de actualización

---

## Gestión de usuarios

Se implementó un módulo adicional para administración de usuarios.

Permite:

* Registrar usuario
* Editar usuario
* Eliminar usuario
* Listar usuarios

---

## Historial de movimientos

Se implementó un módulo de auditoría que registra automáticamente cada movimiento realizado sobre las tareas.

Se registran acciones de:

* Crear
* Editar
* Eliminar

Cada registro almacena:

* Usuario
* Fecha
* Acción
* Tarea
* Descripción del movimiento

---

# Seguridad

La aplicación implementa autenticación mediante JSON Web Token (JWT).

El flujo de autenticación consiste en:

1. Inicio de sesión.
2. Generación del Token JWT.
3. Almacenamiento del Token en Local Storage.
4. Envío automático del Token mediante el encabezado Authorization: Bearer.
5. Protección de los endpoints mediante el atributo `[Authorize]`.

---

# Documentación de la API

La API cuenta con documentación mediante Swagger.

Al ejecutar el proyecto puede consultarse desde:

```
https://localhost:7021/swagger
```

---

# Base de datos

Motor utilizado:

* SQL Server

Tablas principales:

* Usuarios
* Tareas
* CatEstados
* CatPrioridades
* LogTareas

---

# Cómo ejecutar el proyecto

## Backend

1. Abrir la solución en Visual Studio.
2. Restaurar paquetes NuGet.
3. Configurar la cadena de conexión en:

```
appsettings.json
```

4. Ejecutar el proyecto.

La API estará disponible en:

```
https://localhost:7021
```

---

## Frontend

Ingresar al proyecto React.

Instalar dependencias:

```
npm install
```

Ejecutar:

```
npm run dev
```

La aplicación estará disponible en:

```
http://localhost:5174
```

---

# Variables de configuración

Las configuraciones sensibles se encuentran en:

```
appsettings.json
```

Incluyen:

* Cadena de conexión SQL Server
* Llave JWT
* Issuer
* Audience

---

# Decisiones técnicas

Durante el desarrollo se tomaron las siguientes decisiones:

* Uso de DTOs para desacoplar la API del modelo de datos.
* Implementación de arquitectura por capas para mejorar mantenibilidad.
* Entity Framework Core como ORM para acceso a datos.
* SQL Server como motor de persistencia.
* Autenticación basada en JWT.
* Consumo de servicios mediante Axios.
* Componentización en React.
* Registro automático de movimientos mediante una tabla de Logs para auditoría.

---

# Funcionalidades adicionales

Además de los requerimientos solicitados, se implementaron:

* Dashboard principal.
* Administración de usuarios.
* Historial de movimientos.
* Filtros por Estado y Prioridad.
* Validaciones básicas.
* Manejo de errores HTTP.
* Diseño responsive básico.

---

# Evidencia

Se incluyen:

* Código fuente.
* Script de base de datos SQL Server.
* Capturas de pantalla.
* Video demostrativo del funcionamiento.

---

# Autor

*Jocelyn Andrade*

Desarrollado como ejercicio técnico para proceso de selección.
