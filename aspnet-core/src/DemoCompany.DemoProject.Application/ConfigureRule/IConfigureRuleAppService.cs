using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DemoCompany.DemoProject.ConfigureRule.Dto;

namespace DemoCompany.DemoProject.ConfigureRule
{
    public interface IConfigureRuleAppService : IApplicationService
    {
        Task<ListResultDto<ConfigureRuleDto>> GetConfigureRules();

        Task<long> CreateAsync(CreateConfigureRuleDto input);
        
        Task DeleteAsync(EntityDto<long> input);
        
        Task<ConfigureRuleDto> GetAsync(EntityDto<long> input);
        
        Task<long> UpdateAsync(EditConfigureRuleDto input);
    }
}
