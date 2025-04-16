using Abp.Application.Services;
using test.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace test.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
