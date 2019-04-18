FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore WebAPIDocker.csproj
COPY . ./
RUN dotnet publish -c Debug -o /app

# FROM build AS publish
# RUN dotnet publish "WebAPIDocker.csproj" -c Release -o /app
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch
# WORKDIR /app
# COPY --from=build-env /app/out ./
# ENTRYPOINT ["dotnet", "WebAPIDocker.dll"]

FROM base AS final
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "WebAPIDocker.dll"]