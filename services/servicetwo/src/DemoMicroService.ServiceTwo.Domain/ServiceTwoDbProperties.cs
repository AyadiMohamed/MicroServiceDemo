namespace DemoMicroService.ServiceTwo;

public static class ServiceTwoDbProperties
{
    public static string DbTablePrefix { get; set; } = "ServiceTwo";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ServiceTwo";
}
