using DemoMicroService.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}