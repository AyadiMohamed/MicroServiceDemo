using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class ServiceTwoApplicationTestBase<TStartupModule> : ServiceTwoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
