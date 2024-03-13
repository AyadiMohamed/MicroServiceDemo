using DemoMicroService.ServiceOne.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.ServiceOne;

public abstract class ServiceOneAppService : ApplicationService
{
    protected ServiceOneAppService()
    {
        LocalizationResource = typeof(ServiceOneResource);
        ObjectMapperContext = typeof(ServiceOneApplicationModule);
    }
}
