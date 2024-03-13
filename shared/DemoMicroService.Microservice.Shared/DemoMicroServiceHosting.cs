
using DemoMicroService.Administration.EntityFrameworkCore;
using DemoMicroService.Hosting.Shared;
using DemoMicroService.SaaS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DemoMicroService.Microservice.Shared
{
    [DependsOn(
        typeof(DemoMicroServiceHostingModule),
        typeof(AdministrationEntityFrameworkCoreModule),
        typeof(SaaSEntityFrameworkCoreModule)
    )]
    public class DemoMicroServiceHosting : AbpModule
    {
    }
}
