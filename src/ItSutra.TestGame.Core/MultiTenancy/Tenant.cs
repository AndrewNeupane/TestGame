using Abp.MultiTenancy;
using ItSutra.TestGame.Authorization.Users;

namespace ItSutra.TestGame.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
