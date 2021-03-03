using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DemoCompany.DemoProject.Authorization.Roles;
using DemoCompany.DemoProject.Authorization.Users;
using DemoCompany.DemoProject.MultiTenancy;

namespace DemoCompany.DemoProject.EntityFrameworkCore
{
    public class DemoProjectDbContext : AbpZeroDbContext<Tenant, Role, User, DemoProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public DemoProjectDbContext(DbContextOptions<DemoProjectDbContext> options)
            : base(options)
        {
        }
    }
}
