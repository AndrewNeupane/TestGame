using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ItSutra.TestGame.Authorization;

namespace ItSutra.TestGame
{
    [DependsOn(
        typeof(TestGameCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestGameApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestGameAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestGameApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
