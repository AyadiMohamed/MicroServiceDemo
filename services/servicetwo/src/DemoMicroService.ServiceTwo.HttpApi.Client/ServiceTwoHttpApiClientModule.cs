using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ServiceTwoHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ServiceTwoApplicationContractsModule).Assembly,
            ServiceTwoRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ServiceTwoHttpApiClientModule>();
        });

    }
}
