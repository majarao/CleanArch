#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CleanArch.API/CleanArch.API.csproj", "CleanArch.API/"]
COPY ["CleanArch.IoC/CleanArch.CrossCutting.csproj", "CleanArch.IoC/"]
COPY ["CleanArch.Application/CleanArch.Application.csproj", "CleanArch.Application/"]
COPY ["CleanArh.Domain/CleanArch.Domain.csproj", "CleanArh.Domain/"]
COPY ["CleanArch.Infrastructure/CleanArch.Infrastructure.csproj", "CleanArch.Infrastructure/"]
RUN dotnet restore "./CleanArch.API/CleanArch.API.csproj"
COPY . .
WORKDIR "/src/CleanArch.API"
RUN dotnet build "./CleanArch.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanArch.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArch.API.dll"]