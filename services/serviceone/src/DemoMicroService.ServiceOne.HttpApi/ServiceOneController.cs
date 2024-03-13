using DemoMicroService.ServiceOne.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoMicroService.ServiceOne;

public abstract class ServiceOneController : AbpControllerBase
{
    protected ServiceOneController()
    {
        LocalizationResource = typeof(ServiceOneResource);
    }
}
