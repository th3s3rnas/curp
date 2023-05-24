using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using QualisTechnologiesCurpSolution.Configuration;

namespace QualisTechnologiesCurpSolution.Web.Host.Startup
{
    [DependsOn(
       typeof(QualisTechnologiesCurpSolutionWebCoreModule))]
    public class QualisTechnologiesCurpSolutionWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public QualisTechnologiesCurpSolutionWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(QualisTechnologiesCurpSolutionWebHostModule).GetAssembly());
        }
    }
}
