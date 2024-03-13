using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneApplicationModule),
    typeof(ServiceOneDomainTestModule)
    )]
public class ServiceOneApplicationTestModule : AbpModule
{

}
