#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/EventStorm.API/EventStorm.API.csproj", "src/EventStorm.API/"]
COPY ["src/EventStorm.Application/EventStorm.Application.csproj", "src/EventStorm.Application/"]
COPY ["src/EventStorm.Domain/EventStorm.Domain.csproj", "src/EventStorm.Domain/"]
COPY ["src/EventStorm.Infrastructure/EventStorm.Infrastructure.csproj", "src/EventStorm.Infrastructure/"]
RUN dotnet restore "src/EventStorm.API/EventStorm.API.csproj"
COPY . .
WORKDIR "/src/src/EventStorm.API"
RUN dotnet build "EventStorm.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventStorm.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventStorm.API.dll"]