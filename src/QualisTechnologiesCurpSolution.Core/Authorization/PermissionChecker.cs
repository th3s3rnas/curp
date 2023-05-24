using Abp.Authorization;
using QualisTechnologiesCurpSolution.Authorization.Roles;
using QualisTechnologiesCurpSolution.Authorization.Users;

namespace QualisTechnologiesCurpSolution.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
