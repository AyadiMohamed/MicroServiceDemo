using Volo.Abp.Reflection;

namespace DemoMicroService.ServiceTwo.Permissions;

public class ServiceTwoPermissions
{
    public const string GroupName = "ServiceTwo";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ServiceTwoPermissions));
    }
}
