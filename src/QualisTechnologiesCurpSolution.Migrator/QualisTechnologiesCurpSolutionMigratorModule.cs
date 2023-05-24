using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualisTechnologiesCurpSolution.Configuration;
using QualisTechnologiesCurpSolution.EntityFrameworkCore;
using QualisTechnologiesCurpSolution.Migrator.DependencyInjection;

namespace QualisTechnologiesCurpSolution.Migrator
{
    [DependsOn(typeof(QualisTechnologiesCurpSolutionEntityFrameworkModule))]
    public class QualisTechnologiesCurpSolutionMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public QualisTechnologiesCurpSolutionMigratorModule(QualisTechnologiesCurpSolutionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(QualisTechnologiesCurpSolutionMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                QualisTechnologiesCurpSolutionConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualisTechnologiesCurpSolutionMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
