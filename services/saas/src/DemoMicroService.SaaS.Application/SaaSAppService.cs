using DemoMicroService.SaaS.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.SaaS;

public abstract class SaaSAppService : ApplicationService
{
    protected SaaSAppService()
    {
        LocalizationResource = typeof(SaaSResource);
        ObjectMapperContext = typeof(SaaSApplicationModule);
    }
}