FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /project
COPY ["src/EventStorm.API/EventStorm.API.csproj", "src/EventStorm.API/"]
COPY . .
WORKDIR "//project/src/EventStorm.API"
RUN dotnet build "EventStorm.API.csproj" -c Release -o /app/buildhttp


FROM build AS publish
RUN dotnet publish "EventStorm.API.csproj" -c Release -o /app/publish
FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventStorm.API.dll"]