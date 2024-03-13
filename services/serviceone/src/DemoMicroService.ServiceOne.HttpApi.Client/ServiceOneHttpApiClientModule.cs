using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class ServiceOneHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(ServiceOneApplicationContractsModule).Assembly,
            ServiceOneRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<ServiceOneHttpApiClientModule>();
        });

    }
}
