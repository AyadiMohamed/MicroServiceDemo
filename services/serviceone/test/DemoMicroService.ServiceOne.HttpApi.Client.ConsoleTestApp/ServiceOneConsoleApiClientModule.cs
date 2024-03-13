using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ServiceOneHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ServiceOneConsoleApiClientModule : AbpModule
{

}
