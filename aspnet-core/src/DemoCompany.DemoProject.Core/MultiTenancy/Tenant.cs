using Abp.MultiTenancy;
using DemoCompany.DemoProject.Authorization.Users;

namespace DemoCompany.DemoProject.MultiTenancy
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
