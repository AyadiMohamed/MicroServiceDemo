#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["shared/DemoMicroService.DbMigrator/DemoMicroService.DbMigrator.csproj", "shared/DemoMicroService.DbMigrator/"]
COPY ["services/administration/src/DemoMicroService.Administration.Application.Contracts/DemoMicroService.Administration.Application.Contracts.csproj", "services/administration/src/DemoMicroService.Administration.Application.Contracts/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain.Shared/DemoMicroService.Administration.Domain.Shared.csproj", "services/administration/src/DemoMicroService.Administration.Domain.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/DemoMicroService.Administration.EntityFrameworkCore.csproj", "services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain/DemoMicroService.Administration.Domain.csproj", "services/administration/src/DemoMicroService.Administration.Domain/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Application.Contracts/DemoMicroService.IdentityService.Application.Contracts.csproj", "services/identity/src/DemoMicroService.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Domain.Shared/DemoMicroService.IdentityService.Domain.Shared.csproj", "services/identity/src/DemoMicroService.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.EntityFrameworkCore/DemoMicroService.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/DemoMicroService.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Domain/DemoMicroService.IdentityService.Domain.csproj", "services/identity/src/DemoMicroService.IdentityService.Domain/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Application.Contracts/DemoMicroService.SaaS.Application.Contracts.csproj", "services/saas/src/DemoMicroService.SaaS.Application.Contracts/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain.Shared/DemoMicroService.SaaS.Domain.Shared.csproj", "services/saas/src/DemoMicroService.SaaS.Domain.Shared/"]
COPY ["services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/DemoMicroService.SaaS.EntityFrameworkCore.csproj", "services/saas/src/DemoMicroService.SaaS.EntityFrameworkCore/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain/DemoMicroService.SaaS.Domain.csproj", "services/saas/src/DemoMicroService.SaaS.Domain/"]
COPY ["shared/DemoMicroService.Microservice.Shared/DemoMicroService.Microservice.Shared.csproj", "shared/DemoMicroService.Microservice.Shared/"]
COPY ["shared/DemoMicroService.Hosting.Shared/DemoMicroService.Hosting.Shared.csproj", "shared/DemoMicroService.Hosting.Shared/"]
RUN dotnet restore "shared/DemoMicroService.DbMigrator/DemoMicroService.DbMigrator.csproj"
COPY . .
WORKDIR "/src/shared/DemoMicroService.DbMigrator"
RUN dotnet build "DemoMicroService.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoMicroService.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMicroService.DbMigrator.dll"]