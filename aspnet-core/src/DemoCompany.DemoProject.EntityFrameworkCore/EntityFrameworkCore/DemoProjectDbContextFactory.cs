using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DemoCompany.DemoProject.Configuration;
using DemoCompany.DemoProject.Web;

namespace DemoCompany.DemoProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DemoProjectDbContextFactory : IDesignTimeDbContextFactory<DemoProjectDbContext>
    {
        public DemoProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DemoProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DemoProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DemoProjectConsts.ConnectionStringName));

            return new DemoProjectDbContext(builder.Options);
        }
    }
}
