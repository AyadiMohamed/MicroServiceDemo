using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoDomainModule),
    typeof(ServiceTwoApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class ServiceTwoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<ServiceTwoApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ServiceTwoApplicationModule>(validate: true);
        });
    }
}
