using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace QualisTechnologiesCurpSolution.Controllers
{
    public abstract class QualisTechnologiesCurpSolutionControllerBase: AbpController
    {
        protected QualisTechnologiesCurpSolutionControllerBase()
        {
            LocalizationSourceName = QualisTechnologiesCurpSolutionConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
