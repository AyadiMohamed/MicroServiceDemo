using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceOne;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class ServiceOneDomainTestBase<TStartupModule> : ServiceOneTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
