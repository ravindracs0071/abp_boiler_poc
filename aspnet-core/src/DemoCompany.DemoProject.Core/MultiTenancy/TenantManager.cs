using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using DemoCompany.DemoProject.Authorization.Users;
using DemoCompany.DemoProject.Editions;

namespace DemoCompany.DemoProject.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
