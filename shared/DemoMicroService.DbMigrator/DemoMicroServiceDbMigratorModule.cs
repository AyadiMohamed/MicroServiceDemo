using DemoMicroService.Administration;
using DemoMicroService.Administration.EntityFrameworkCore;
using DemoMicroService.IdentityService;
using DemoMicroService.IdentityService.EntityFrameworkCore;
using DemoMicroService.Microservice.Shared;
using DemoMicroService.SaaS;
using DemoMicroService.SaaS.EntityFrameworkCore;
using DemoMicroService.ServiceOne;
using DemoMicroService.ServiceOne.EntityFrameworkCore;
using DemoMicroService.ServiceTwo;
using DemoMicroService.ServiceTwo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DemoMicroService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationEntityFrameworkCoreModule),
    typeof(AdministrationApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaaSEntityFrameworkCoreModule),
    typeof(SaaSApplicationContractsModule),
    typeof(ServiceOneEntityFrameworkCoreModule),
    typeof(ServiceOneApplicationContractsModule),
    typeof(ServiceTwoEntityFrameworkCoreModule),
    typeof(ServiceTwoApplicationContractsModule)
)]
public class DemoMicroServiceDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}