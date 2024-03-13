using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ServiceOneApplicationContractsModule : AbpModule
{

}
