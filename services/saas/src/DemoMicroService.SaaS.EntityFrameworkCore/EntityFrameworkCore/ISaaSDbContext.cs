using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.SaaS.EntityFrameworkCore;

[ConnectionStringName(SaaSDbProperties.ConnectionStringName)]
public interface ISaaSDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}