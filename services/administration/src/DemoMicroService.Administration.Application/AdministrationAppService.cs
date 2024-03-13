using DemoMicroService.Administration.Localization;
using Volo.Abp.Application.Services;

namespace DemoMicroService.Administration;

public abstract class AdministrationAppService : ApplicationService
{
    protected AdministrationAppService()
    {
        LocalizationResource = typeof(AdministrationResource);
        ObjectMapperContext = typeof(AdministrationApplicationModule);
    }
}