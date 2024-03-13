#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["services/administration/NuGet.Config", "services/administration/"]
COPY ["services/identity/NuGet.Config", "services/identity/"]
COPY ["services/saas/NuGet.Config", "services/saas/"]
COPY ["services/administration/host/DemoMicroService.Administration.HttpApi.Host/DemoMicroService.Administration.HttpApi.Host.csproj", "services/administration/host/DemoMicroService.Administration.HttpApi.Host/"]
COPY ["shared/DemoMicroService.Hosting.Shared/DemoMicroService.Hosting.Shared.csproj", "shared/DemoMicroService.Hosting.Shared/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Application.Contracts/DemoMicroService.IdentityService.Application.Contracts.csproj", "services/identity/src/DemoMicroService.IdentityService.Application.Contracts/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Domain.Shared/DemoMicroService.IdentityService.Domain.Shared.csproj", "services/identity/src/DemoMicroService.IdentityService.Domain.Shared/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.EntityFrameworkCore/DemoMicroService.IdentityService.EntityFrameworkCore.csproj", "services/identity/src/DemoMicroService.IdentityService.EntityFrameworkCore/"]
COPY ["services/identity/src/DemoMicroService.IdentityService.Domain/DemoMicroService.IdentityService.Domain.csproj", "services/identity/src/DemoMicroService.IdentityService.Domain/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Application.Contracts/DemoMicroService.SaaS.Application.Contracts.csproj", "services/saas/src/DemoMicroService.SaaS.Application.Contracts/"]
COPY ["services/saas/src/DemoMicroService.SaaS.Domain.Shared/DemoMicroService.SaaS.Domain.Shared.csproj", "services/saas/src/DemoMicroService.SaaS.Domain.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.HttpApi/DemoMicroService.Administration.HttpApi.csproj", "services/administration/src/DemoMicroService.Administration.HttpApi/"]
COPY ["services/administration/src/DemoMicroService.Administration.Application.Contracts/DemoMicroService.Administration.Application.Contracts.csproj", "services/administration/src/DemoMicroService.Administration.Application.Contracts/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain.Shared/DemoMicroService.Administration.Domain.Shared.csproj", "services/administration/src/DemoMicroService.Administration.Domain.Shared/"]
COPY ["services/administration/src/DemoMicroService.Administration.Application/DemoMicroService.Administration.Application.csproj", "services/administration/src/DemoMicroService.Administration.Application/"]
COPY ["services/administration/src/DemoMicroService.Administration.Domain/DemoMicroService.Administration.Domain.csproj", "services/administration/src/DemoMicroService.Administration.Domain/"]
COPY ["services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/DemoMicroService.Administration.EntityFrameworkCore.csproj", "services/administration/src/DemoMicroService.Administration.EntityFrameworkCore/"]
RUN dotnet restore "services/administration/host/DemoMicroService.Administration.HttpApi.Host/DemoMicroService.Administration.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/services/administration/host/DemoMicroService.Administration.HttpApi.Host"
RUN dotnet build "DemoMicroService.Administration.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoMicroService.Administration.HttpApi.Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoMicroService.Administration.HttpApi.Host.dll"]