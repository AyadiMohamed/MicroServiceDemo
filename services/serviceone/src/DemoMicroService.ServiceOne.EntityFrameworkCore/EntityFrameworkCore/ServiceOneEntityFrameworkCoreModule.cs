using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne.EntityFrameworkCore;

[DependsOn(
    typeof(ServiceOneDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class ServiceOneEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ServiceOneDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(true);
        });
    }
}
