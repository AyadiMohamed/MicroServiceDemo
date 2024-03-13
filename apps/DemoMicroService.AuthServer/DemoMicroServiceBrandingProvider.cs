using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DemoMicroService;

[Dependency(ReplaceServices = true)]
public class DemoMicroServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DemoMicroService";
}
