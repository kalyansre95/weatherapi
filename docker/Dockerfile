#Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ../api/WeatherAPI/*.csproj .
RUN dotnet restore
COPY ../api/WeatherAPI/. .
RUN dotnet publish -c Release -o /app/publish

#RUNTIME STAGE
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet","WeatherAPI.dll"]

