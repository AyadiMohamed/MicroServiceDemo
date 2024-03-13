using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoMicroService.Blazor;

[Dependency(ReplaceServices = true)]
public class DemoMicroServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DemoMicroService";
}
