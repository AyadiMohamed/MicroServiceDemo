using Volo.Abp.Reflection;

namespace DemoMicroService.ServiceOne.Permissions;

public class ServiceOnePermissions
{
    public const string GroupName = "ServiceOne";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ServiceOnePermissions));
    }
}
