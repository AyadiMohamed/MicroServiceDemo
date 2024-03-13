using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneDomainModule),
    typeof(ServiceOneTestBaseModule)
)]
public class ServiceOneDomainTestModule : AbpModule
{

}
