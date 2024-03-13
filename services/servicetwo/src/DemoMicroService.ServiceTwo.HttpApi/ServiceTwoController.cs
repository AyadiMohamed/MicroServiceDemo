using DemoMicroService.ServiceTwo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.ServiceTwo;

public abstract class ServiceTwoController : AbpControllerBase
{
    protected ServiceTwoController()
    {
        LocalizationResource = typeof(ServiceTwoResource);
    }
}
