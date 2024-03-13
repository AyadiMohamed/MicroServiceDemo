using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoDomainModule),
    typeof(ServiceTwoTestBaseModule)
)]
public class ServiceTwoDomainTestModule : AbpModule
{

}
