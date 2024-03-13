using DemoMicroService.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}