using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoMicroService.ServiceTwo.EntityFrameworkCore
{
    public class ProjectServiceDbContextFactory : IDesignTimeDbContextFactory<ServiceTwoDbContext>
    {
        public ServiceTwoDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ServiceTwoDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());

            return new ServiceTwoDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration()
                .GetConnectionString(ServiceTwoDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}DemoMicroService.ServiceTwo.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }

}
