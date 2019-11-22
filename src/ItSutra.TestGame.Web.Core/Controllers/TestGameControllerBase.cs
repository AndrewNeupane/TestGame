using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ItSutra.TestGame.Controllers
{
    public abstract class TestGameControllerBase: AbpController
    {
        protected TestGameControllerBase()
        {
            LocalizationSourceName = TestGameConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
