using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.ServiceOne.EntityFrameworkCore;

[ConnectionStringName(ServiceOneDbProperties.ConnectionStringName)]
public interface IServiceOneDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
