using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo.EntityFrameworkCore;

[DependsOn(
    typeof(ServiceTwoDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ServiceTwoEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ServiceTwoDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
