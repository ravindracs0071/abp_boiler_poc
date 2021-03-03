using Abp.Application.Services;
using DemoCompany.DemoProject.MultiTenancy.Dto;

namespace DemoCompany.DemoProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

