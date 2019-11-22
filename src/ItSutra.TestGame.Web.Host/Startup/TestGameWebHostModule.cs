using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ItSutra.TestGame.Configuration;

namespace ItSutra.TestGame.Web.Host.Startup
{
    [DependsOn(
       typeof(TestGameWebCoreModule))]
    public class TestGameWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TestGameWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TestGameWebHostModule).GetAssembly());
        }
    }
}
