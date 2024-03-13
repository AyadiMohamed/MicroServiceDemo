using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ServiceTwoHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class ServiceTwoConsoleApiClientModule : AbpModule
{

}
