using DemoMicroService.ServiceTwo.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.ServiceTwo;

public abstract class ServiceTwoAppService : ApplicationService
{
    protected ServiceTwoAppService()
    {
        LocalizationResource = typeof(ServiceTwoResource);
        ObjectMapperContext = typeof(ServiceTwoApplicationModule);
    }
}
