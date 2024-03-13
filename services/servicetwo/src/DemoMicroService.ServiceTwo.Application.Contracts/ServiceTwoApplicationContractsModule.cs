using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ServiceTwoApplicationContractsModule : AbpModule
{

}
