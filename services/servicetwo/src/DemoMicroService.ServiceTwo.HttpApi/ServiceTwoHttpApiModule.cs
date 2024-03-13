using Localization.Resources.AbpUi;
using DemoMicroService.ServiceTwo.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMicroService.ServiceTwo;

[DependsOn(
    typeof(ServiceTwoApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ServiceTwoHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ServiceTwoHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ServiceTwoResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
