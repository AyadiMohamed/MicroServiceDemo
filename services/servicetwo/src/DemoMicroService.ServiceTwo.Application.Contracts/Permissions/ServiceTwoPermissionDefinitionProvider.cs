using DemoMicroService.ServiceTwo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DemoMicroService.ServiceTwo.Permissions;

public class ServiceTwoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ServiceTwoPermissions.GroupName, L("Permission:ServiceTwo"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ServiceTwoResource>(name);
    }
}
