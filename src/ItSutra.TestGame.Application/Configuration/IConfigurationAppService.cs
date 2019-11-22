using System.Threading.Tasks;
using ItSutra.TestGame.Configuration.Dto;

namespace ItSutra.TestGame.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
