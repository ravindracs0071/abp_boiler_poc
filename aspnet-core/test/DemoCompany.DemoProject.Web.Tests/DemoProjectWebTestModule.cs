using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DemoCompany.DemoProject.EntityFrameworkCore;
using DemoCompany.DemoProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DemoCompany.DemoProject.Web.Tests
{
    [DependsOn(
        typeof(DemoProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DemoProjectWebTestModule : AbpModule
    {
        public DemoProjectWebTestModule(DemoProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DemoProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DemoProjectWebMvcModule).Assembly);
        }
    }
}