using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace DemoMicroService.ServiceOne.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
