using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoMicroService.ServiceOne.EntityFrameworkCore
{
    public class ServiceOneeDbContextFactory : IDesignTimeDbContextFactory<ServiceOneDbContext>
    {
        public ServiceOneDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ServiceOneDbContext>()
                .UseNpgsql(GetConnectionStringFromConfiguration());

            return new ServiceOneDbContext(builder.Options);
        }

        private static string GetConnectionStringFromConfiguration()
        {
            return BuildConfiguration().GetConnectionString(ServiceOneDbProperties.ConnectionStringName);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetParent(Directory.GetCurrentDirectory())?.Parent!.FullName!,
                        $"host{Path.DirectorySeparatorChar}DemoMicroService.ServiceOne.HttpApi.Host"
                    )
                )
                .AddJsonFile("appsettings.json", false);

            return builder.Build();
        }
    }

}
