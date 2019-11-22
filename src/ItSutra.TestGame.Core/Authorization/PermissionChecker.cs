using Abp.Authorization;
using ItSutra.TestGame.Authorization.Roles;
using ItSutra.TestGame.Authorization.Users;

namespace ItSutra.TestGame.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
