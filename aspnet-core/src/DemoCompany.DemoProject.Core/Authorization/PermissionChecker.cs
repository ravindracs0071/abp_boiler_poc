using Abp.Authorization;
using DemoCompany.DemoProject.Authorization.Roles;
using DemoCompany.DemoProject.Authorization.Users;

namespace DemoCompany.DemoProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
