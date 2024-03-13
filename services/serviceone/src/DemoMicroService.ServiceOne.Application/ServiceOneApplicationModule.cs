using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneDomainModule),
    typeof(ServiceOneApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class ServiceOneApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ServiceOneApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ServiceOneApplicationModule>(validate: true);
        });
    }
}
