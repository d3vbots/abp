using Abp.Application.Services;
using test.Sessions.Dto;
using System.Threading.Tasks;

namespace test.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
