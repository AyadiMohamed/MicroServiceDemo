using Volo.Abp.Modularity;

namespace DemoMicroService.Administration;

[DependsOn(
    typeof(AdministrationApplicationModule),
    typeof(AdministrationDomainTestModule)
    )]
public class AdministrationApplicationTestModule : AbpModule
{

}
