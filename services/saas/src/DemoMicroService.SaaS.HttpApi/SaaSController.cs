using DemoMicroService.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}