using DemoMicroService.ServiceOne.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DemoMicroService.ServiceOne.Permissions;

public class ServiceOnePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ServiceOnePermissions.GroupName, L("Permission:ServiceOne"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ServiceOneResource>(name);
    }
}
