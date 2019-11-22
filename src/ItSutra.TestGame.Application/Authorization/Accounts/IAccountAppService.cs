using System.Threading.Tasks;
using Abp.Application.Services;
using ItSutra.TestGame.Authorization.Accounts.Dto;

namespace ItSutra.TestGame.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
