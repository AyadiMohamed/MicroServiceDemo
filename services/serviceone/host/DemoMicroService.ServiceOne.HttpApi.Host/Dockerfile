#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/serviceone/NuGet.Config", "services/serviceone/"]
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/serviceone/host/DemoMicroService.ServiceOne.HttpApi.Host/DemoMicroService.ServiceOne.HttpApi.Host.csproj", "services/serviceone/host/DemoMicroService.ServiceOne.HttpApi.Host/"]
COPY ["shared/DemoMicroService.Microservice.Shared/DemoMicroService.Microservice.Shared.csproj", "shared/DemoMicroService.Microservice.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/DemoMicroService.Administration.EntityFrameworkCore.csproj", "services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain/DemoMicroService.Administration.Domain.csproj", "services/administration/src/DemoMicroService.Administration.Domain/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain.Shared/DemoMicroService.Administration.Domain.Shared.csproj", "services/administration/src/DemoMicroService.Administration.Domain.Shared/"]
COPY ["services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/DemoMicroService.SaaS.EntityFrameworkCore.csproj", "services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain/DemoMicroService.SaaS.Domain.csproj", "services/saas/src/DemoMicroService.SaaS.Domain/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain.Shared/DemoMicroService.SaaS.Domain.Shared.csproj", "services/saas/src/DemoMicroService.SaaS.Domain.Shared/"]
COPY ["shared/DemoMicroService.Hosting.Shared/DemoMicroService.Hosting.Shared.csproj", "shared/DemoMicroService.Hosting.Shared/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.HttpApi/DemoMicroService.ServiceOne.HttpApi.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.HttpApi/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.Application.Contracts/DemoMicroService.ServiceOne.Application.Contracts.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.Application.Contracts/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.Domain.Shared/DemoMicroService.ServiceOne.Domain.Shared.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.Domain.Shared/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.Application/DemoMicroService.ServiceOne.Application.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.Application/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.Domain/DemoMicroService.ServiceOne.Domain.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.Domain/"]
COPY ["services/serviceone/src/DemoMicroService.ServiceOne.EntityFrameworkCore/DemoMicroService.ServiceOne.EntityFrameworkCore.csproj", "services/serviceone/src/DemoMicroService.ServiceOne.EntityFrameworkCore/"]
RUN dotnet restore "./services/serviceone/host/DemoMicroService.ServiceOne.HttpApi.Host/./DemoMicroService.ServiceOne.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/serviceone/host/DemoMicroService.ServiceOne.HttpApi.Host"
RUN dotnet build "./DemoMicroService.ServiceOne.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DemoMicroService.ServiceOne.HttpApi.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMicroService.ServiceOne.HttpApi.Host.dll"]