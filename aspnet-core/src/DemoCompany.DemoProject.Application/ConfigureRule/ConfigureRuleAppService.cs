using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Runtime.Session;
using DemoCompany.DemoProject.ConfigureRule.Dto;
using DemoCompany.DemoProject.MultiTenancy;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Abp.Domain.Entities;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.UI;
using DemoCompany.DemoProject.Authorization;
using DemoCompany.DemoProject.Authorization.Accounts;
using DemoCompany.DemoProject.Authorization.Roles;
using DemoCompany.DemoProject.Authorization.Users;
using DemoCompany.DemoProject.Roles.Dto;
using DemoCompany.DemoProject.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoCompany.DemoProject.ConfigureRule
{
    [AbpAuthorize]
    public class ConfigureRuleAppService : DemoProjectAppServiceBase, IConfigureRuleAppService 
    {
        private readonly IRepository<ConfigureRule, long> _configRuleRepository;
        private readonly IAbpSession _abpSession;

        public ConfigureRuleAppService(
            IRepository<ConfigureRule, long> configRuleRepository,
            IAbpSession abpSession)
        {
            _configRuleRepository = configRuleRepository;
            _abpSession = abpSession;
        }

        public async Task<long> CreateAsync(CreateConfigureRuleDto input)
        {
            try 
            {
                //CheckCreatePermission();

                var configureRuleInput = ObjectMapper.Map<ConfigureRule>(input);

                configureRuleInput.TenantId = _abpSession.TenantId.Value;

                long id = await _configRuleRepository.InsertAndGetIdAsync(configureRuleInput);
                configureRuleInput.Id = id;
                await CurrentUnitOfWork.SaveChangesAsync();
                return id;
            }
            catch (System.Exception ex) 
            { 
                throw new UserFriendlyException("An internal error occurred during your request"); 
            }
        }

        public async Task<long> UpdateAsync(EditConfigureRuleDto input)
        {
            try
            {
                var configureRule = await _configRuleRepository.GetAsync(input.Id);

                ObjectMapper.Map(input, configureRule);

                await _configRuleRepository.UpdateAsync(configureRule);

                await CurrentUnitOfWork.SaveChangesAsync();
                
                return configureRule.Id;
            }
            catch (System.Exception ex)
            {
                throw new UserFriendlyException("An internal error occurred during your request");
            }
        }

        public async Task DeleteAsync(EntityDto<long> input)
        {
            var configureRule = await _configRuleRepository.GetAsync(input.Id);

            await CurrentUnitOfWork.SaveChangesAsync();

            await _configRuleRepository.DeleteAsync(configureRule);
        }

        public async Task<ListResultDto<ConfigureRuleDto>> GetConfigureRules()
        {
            var configureRules = await _configRuleRepository.GetAllListAsync();
            return new ListResultDto<ConfigureRuleDto>(ObjectMapper.Map<List<ConfigureRuleDto>>(configureRules));
        }

        protected IQueryable<ConfigureRule> CreateFilteredQuery(PagedConfigureRuleResultRequestDto input)
        {
            return _configRuleRepository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.RuleForProperty.Contains(input.Keyword) || x.SyntaxForProperty.Contains(input.Keyword));
        }

        protected async Task<ConfigureRule> GetEntityByIdAsync(long id)
        {
            var configureRule = await _configRuleRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (configureRule == null)
            {
                throw new EntityNotFoundException(typeof(ConfigureRule), id);
            }

            return configureRule;
        }

        public async Task<ConfigureRuleDto> GetAsync(EntityDto<long> input)
        {
            var configureRule = await _configRuleRepository.GetAsync(input.Id);
            return ObjectMapper.Map<ConfigureRuleDto>(configureRule);
        }

        public ConfigureRule GetEntityByRuleForProperty(string ruleForProperty)
        {
            var configureRule = _configRuleRepository.GetAll().FirstOrDefault(x => x.RuleForProperty == ruleForProperty);

            if (configureRule == null)
            {
                return null;
            }

            return configureRule;
        }
    }
}
