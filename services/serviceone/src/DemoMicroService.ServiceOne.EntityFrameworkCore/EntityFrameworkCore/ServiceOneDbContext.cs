using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.ServiceOne.EntityFrameworkCore;

[ConnectionStringName(ServiceOneDbProperties.ConnectionStringName)]
public class ServiceOneDbContext : AbpDbContext<ServiceOneDbContext>, IServiceOneDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
      */
    public DbSet<testEntity> testEntities { get; set; } 

    public ServiceOneDbContext(DbContextOptions<ServiceOneDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureServiceOne();
    }
}
