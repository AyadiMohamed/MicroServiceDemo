using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace DemoMicroService.Administration.EntityFrameworkCore;

[ConnectionStringName(AdministrationDbProperties.ConnectionStringName)]
public interface IAdministrationDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}