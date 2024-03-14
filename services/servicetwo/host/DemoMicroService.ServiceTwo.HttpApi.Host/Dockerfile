#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/servicetwo/NuGet.Config", "services/servicetwo/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/servicetwo/host/DemoMicroService.ServiceTwo.HttpApi.Host/DemoMicroService.ServiceTwo.HttpApi.Host.csproj", "services/servicetwo/host/DemoMicroService.ServiceTwo.HttpApi.Host/"]
COPY ["shared/DemoMicroService.Microservice.Shared/DemoMicroService.Microservice.Shared.csproj", "shared/DemoMicroService.Microservice.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/DemoMicroService.Administration.EntityFrameworkCore.csproj", "services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain/DemoMicroService.Administration.Domain.csproj", "services/administration/src/DemoMicroService.Administration.Domain/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain.Shared/DemoMicroService.Administration.Domain.Shared.csproj", "services/administration/src/DemoMicroService.Administration.Domain.Shared/"]
COPY ["services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/DemoMicroService.SaaS.EntityFrameworkCore.csproj", "services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain/DemoMicroService.SaaS.Domain.csproj", "services/saas/src/DemoMicroService.SaaS.Domain/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain.Shared/DemoMicroService.SaaS.Domain.Shared.csproj", "services/saas/src/DemoMicroService.SaaS.Domain.Shared/"]
COPY ["shared/DemoMicroService.Hosting.Shared/DemoMicroService.Hosting.Shared.csproj", "shared/DemoMicroService.Hosting.Shared/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.HttpApi/DemoMicroService.ServiceTwo.HttpApi.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.HttpApi/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.Application.Contracts/DemoMicroService.ServiceTwo.Application.Contracts.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.Application.Contracts/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.Domain.Shared/DemoMicroService.ServiceTwo.Domain.Shared.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.Domain.Shared/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.Application/DemoMicroService.ServiceTwo.Application.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.Application/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.Domain/DemoMicroService.ServiceTwo.Domain.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.Domain/"]
COPY ["services/servicetwo/src/DemoMicroService.ServiceTwo.EntityFrameworkCore/DemoMicroService.ServiceTwo.EntityFrameworkCore.csproj", "services/servicetwo/src/DemoMicroService.ServiceTwo.EntityFrameworkCore/"]
RUN dotnet restore "./services/servicetwo/host/DemoMicroService.ServiceTwo.HttpApi.Host/./DemoMicroService.ServiceTwo.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/servicetwo/host/DemoMicroService.ServiceTwo.HttpApi.Host"
RUN dotnet build "./DemoMicroService.ServiceTwo.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DemoMicroService.ServiceTwo.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMicroService.ServiceTwo.HttpApi.Host.dll"]