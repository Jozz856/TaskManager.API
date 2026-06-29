# Imagen base para ejecutar la API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080


# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["TaskManager.API.csproj", "./"]

RUN dotnet restore "TaskManager.API.csproj"


COPY . .

RUN dotnet build "TaskManager.API.csproj" -c Release -o /app/build


FROM build AS publish

RUN dotnet publish "TaskManager.API.csproj" -c Release -o /app/publish


# Imagen final
FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TaskManager.API.dll"]