using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ItSutra.TestGame.Configuration.Dto;

namespace ItSutra.TestGame.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TestGameAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
