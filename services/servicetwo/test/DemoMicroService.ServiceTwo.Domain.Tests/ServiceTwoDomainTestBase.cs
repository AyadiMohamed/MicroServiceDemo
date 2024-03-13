using Volo.Abp.Modularity;

namespace DemoMicroService.ServiceTwo;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class ServiceTwoDomainTestBase<TStartupModule> : ServiceTwoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
