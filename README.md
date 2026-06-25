\# TaskManager API



\## Descripción

API REST para administración de tareas desarrollada con ASP.NET Core.



\## Arquitectura



El proyecto utiliza arquitectura por capas:



\- Controllers

\- DTOs

\- Repositories

\- Services

\- Datos

\- Models



\## Tecnologías utilizadas



\- ASP.NET Core Web API

\- Entity Framework Core

\- SQL Server

\- C#

\- JWT (pendiente si lo agregamos)



\## Decisiones técnicas



\- Uso de DTOs para separar modelos de persistencia.

\- Repository Pattern para acceso a datos.

\- Service Layer para separar lógica de negocio.

\- Entity Framework Core para manejo de base de datos.



\## Ejecución



1\. Clonar repositorio.



2\. Configurar cadena de conexión en:



appsettings.json



3\. Ejecutar migraciones:



dotnet ef database update



4\. Ejecutar API:



dotnet run



\## Base de datos



SQL Server



\## Endpoints principales



GET /api/tareas



POST /api/tareas



PUT /api/tareas/{id}



DELETE /api/tareas/{id}

