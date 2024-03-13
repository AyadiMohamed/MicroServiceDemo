using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ServiceOneDomainSharedModule)
)]
public class ServiceOneDomainModule : AbpModule
{

}
