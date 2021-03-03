using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DemoCompany.DemoProject.Authorization;

namespace DemoCompany.DemoProject
{
    [DependsOn(
        typeof(DemoProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DemoProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DemoProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DemoProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
