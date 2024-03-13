using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class ServiceOneApplicationTestBase<TStartupModule> : ServiceOneTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
