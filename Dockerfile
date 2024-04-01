
# Base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 443
EXPOSE 4003
EXPOSE 5003


# SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de proyecto al contenedor
COPY ["./Iso.Backend.Application/Iso.Backend.Application.csproj", "src/Iso.Backend.Application/"]
COPY ["./Iso.Backend.Domain/Iso.Backend.Domain.csproj", "src/Iso.Backend.Domain/"]
COPY ["./Iso.Backend.Web/Iso.Backend.Web.csproj", "src/Iso.Backend.Web/"]
COPY ["./Iso.Backend.Infrastructure/Iso.Backend.Infrastructure.csproj", "src/Iso.Backend.Infrastructure/"]



# Restaura las dependencias del proyecto
RUN dotnet restore "src/Iso.Backend.Web/Iso.Backend.Web.csproj"


# Copia el resto de los archivos al contenedor
COPY . .

# Compila los proyectos
WORKDIR "/src/Iso.Backend.Web/"
RUN dotnet build -c Release -o /app/build


# Publica los proyectos
FROM build AS publish

RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime

WORKDIR /app
COPY --from=publish /app/publish .
RUN ls -l

ENTRYPOINT ["dotnet", "/app/Iso.Backend.Web.dll"]