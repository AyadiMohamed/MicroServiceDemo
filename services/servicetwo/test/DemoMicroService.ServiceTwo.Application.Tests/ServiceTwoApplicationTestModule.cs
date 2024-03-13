using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoApplicationModule),
    typeof(ServiceTwoDomainTestModule)
    )]
public class ServiceTwoApplicationTestModule : AbpModule
{

}
