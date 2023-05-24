using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualisTechnologiesCurpSolution.Authorization;

namespace QualisTechnologiesCurpSolution
{
    [DependsOn(
        typeof(QualisTechnologiesCurpSolutionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class QualisTechnologiesCurpSolutionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<QualisTechnologiesCurpSolutionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(QualisTechnologiesCurpSolutionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
