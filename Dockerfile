FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish ./PromptitoAPI -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://*:$PORT
ENTRYPOINT ["dotnet", "Promptito.API.dll"]