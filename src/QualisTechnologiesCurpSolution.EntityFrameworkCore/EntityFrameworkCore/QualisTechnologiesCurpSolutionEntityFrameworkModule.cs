using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using QualisTechnologiesCurpSolution.EntityFrameworkCore.Seed;

namespace QualisTechnologiesCurpSolution.EntityFrameworkCore
{
    [DependsOn(
        typeof(QualisTechnologiesCurpSolutionCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class QualisTechnologiesCurpSolutionEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<QualisTechnologiesCurpSolutionDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        QualisTechnologiesCurpSolutionDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        QualisTechnologiesCurpSolutionDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualisTechnologiesCurpSolutionEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
