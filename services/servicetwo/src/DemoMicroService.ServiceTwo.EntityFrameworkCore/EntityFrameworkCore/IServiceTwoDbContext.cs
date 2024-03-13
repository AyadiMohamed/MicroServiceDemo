using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.ServiceTwo.EntityFrameworkCore;

[ConnectionStringName(ServiceTwoDbProperties.ConnectionStringName)]
public interface IServiceTwoDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
