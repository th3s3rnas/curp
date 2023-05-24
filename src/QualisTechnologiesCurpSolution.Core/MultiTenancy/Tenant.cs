using Abp.MultiTenancy;
using QualisTechnologiesCurpSolution.Authorization.Users;

namespace QualisTechnologiesCurpSolution.MultiTenancy
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
