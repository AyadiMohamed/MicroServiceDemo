using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ServiceTwoDomainSharedModule)
)]
public class ServiceTwoDomainModule : AbpModule
{

}
