using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using QualisTechnologiesCurpSolution.Authorization.Roles;
using Abp.Domain.Uow;

namespace QualisTechnologiesCurpSolution.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor,
                  unitOfWorkManager)
        {
        }
    }
}
