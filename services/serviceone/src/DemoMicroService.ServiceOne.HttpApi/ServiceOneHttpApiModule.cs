using Localization.Resources.AbpUi;
using DemoMicroService.ServiceOne.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMicroService.ServiceOne;

[DependsOn(
    typeof(ServiceOneApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class ServiceOneHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(ServiceOneHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ServiceOneResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
