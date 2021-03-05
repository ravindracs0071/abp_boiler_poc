using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using DemoCompany.DemoProject.Authorization.Roles;


namespace DemoCompany.DemoProject.ConfigureRule.Dto
{
    [AutoMapFrom(typeof(ConfigureRule))]
    public class ConfigureRuleDto : EntityDto<long>
    {
        public virtual string RuleForProperty { get; set; }

        public virtual string SyntaxForProperty { get; set; }
    }
}
