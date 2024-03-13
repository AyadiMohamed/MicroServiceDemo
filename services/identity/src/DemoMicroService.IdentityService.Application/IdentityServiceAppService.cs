using DemoMicroService.IdentityService.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.IdentityService;

public abstract class IdentityServiceAppService : ApplicationService
{
    protected IdentityServiceAppService()
    {
        LocalizationResource = typeof(IdentityServiceResource);
        ObjectMapperContext = typeof(IdentityServiceApplicationModule);
    }
}