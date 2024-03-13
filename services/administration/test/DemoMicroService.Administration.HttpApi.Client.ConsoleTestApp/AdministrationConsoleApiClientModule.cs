using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DemoMicroService.Administration;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class AdministrationConsoleApiClientModule : AbpModule
{

}
