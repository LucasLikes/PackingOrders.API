FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo csproj para a pasta /src
COPY PackingOrders.API.csproj ./

# Restaura o projeto pelo caminho correto, sem subpastas
RUN dotnet restore "PackingOrders.API.csproj"

# Copia todos os arquivos da pasta atual (contexto) para /src
COPY . .

WORKDIR "/src"
RUN dotnet build "PackingOrders.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PackingOrders.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PackingOrders.API.dll"]
