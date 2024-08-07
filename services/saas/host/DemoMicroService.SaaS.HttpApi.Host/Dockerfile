#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/host/DemoMicroService.SaaS.HttpApi.Host/DemoMicroService.SaaS.HttpApi.Host.csproj", "services/saas/host/DemoMicroService.SaaS.HttpApi.Host/"]
COPY ["shared/DemoMicroService.Hosting.Shared/DemoMicroService.Hosting.Shared.csproj", "shared/DemoMicroService.Hosting.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/DemoMicroService.Administration.EntityFrameworkCore.csproj", "services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain/DemoMicroService.Administration.Domain.csproj", "services/administration/src/DemoMicroService.Administration.Domain/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain.Shared/DemoMicroService.Administration.Domain.Shared.csproj", "services/administration/src/DemoMicroService.Administration.Domain.Shared/"]
COPY ["services/saas/src/DemoMicroService.SaaS.HttpApi/DemoMicroService.SaaS.HttpApi.csproj", "services/saas/src/DemoMicroService.SaaS.HttpApi/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Application.Contracts/DemoMicroService.SaaS.Application.Contracts.csproj", "services/saas/src/DemoMicroService.SaaS.Application.Contracts/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain.Shared/DemoMicroService.SaaS.Domain.Shared.csproj", "services/saas/src/DemoMicroService.SaaS.Domain.Shared/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Application/DemoMicroService.SaaS.Application.csproj", "services/saas/src/DemoMicroService.SaaS.Application/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain/DemoMicroService.SaaS.Domain.csproj", "services/saas/src/DemoMicroService.SaaS.Domain/"]
COPY ["services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/DemoMicroService.SaaS.EntityFrameworkCore.csproj", "services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/"]
RUN dotnet restore "./services/saas/host/DemoMicroService.SaaS.HttpApi.Host/./DemoMicroService.SaaS.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/saas/host/DemoMicroService.SaaS.HttpApi.Host"
RUN dotnet build "./DemoMicroService.SaaS.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DemoMicroService.SaaS.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMicroService.SaaS.HttpApi.Host.dll"]