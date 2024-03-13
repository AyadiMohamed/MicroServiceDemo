using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.ServiceTwo.EntityFrameworkCore;

[ConnectionStringName(ServiceTwoDbProperties.ConnectionStringName)]
public class ServiceTwoDbContext : AbpDbContext<ServiceTwoDbContext>, IServiceTwoDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public ServiceTwoDbContext(DbContextOptions<ServiceTwoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureServiceTwo();
    }
}
