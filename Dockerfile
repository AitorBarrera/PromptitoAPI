# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy just the project files first for better layer caching
COPY ["PromptitoAPI/Promptito.API.csproj", "PromptitoAPI/"]
COPY ["PromptitoAPI.Core/PromptitoAPI.API.Core.csproj", "PromptitoAPI.Core/"]
RUN dotnet restore "PromptitoAPI/Promptito.API.csproj"

# Copy everything else
COPY . .
WORKDIR "/src/PromptitoAPI"
RUN dotnet build "Promptito.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 2: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Promptito.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app

# Install curl for health checks (optional)
RUN apt-get update && apt-get install -y curl

COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
    CMD curl -f http://localhost/health || exit 1

ENTRYPOINT ["dotnet", "Promptito.API.dll"]