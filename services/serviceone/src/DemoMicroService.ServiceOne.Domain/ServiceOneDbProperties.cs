namespace DemoMicroService.ServiceOne;

public static class ServiceOneDbProperties
{
    public static string DbTablePrefix { get; set; } = "ServiceOne";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ServiceOne";
}
