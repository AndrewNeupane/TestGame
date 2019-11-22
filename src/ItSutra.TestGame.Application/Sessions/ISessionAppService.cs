using System.Threading.Tasks;
using Abp.Application.Services;
using ItSutra.TestGame.Sessions.Dto;

namespace ItSutra.TestGame.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
