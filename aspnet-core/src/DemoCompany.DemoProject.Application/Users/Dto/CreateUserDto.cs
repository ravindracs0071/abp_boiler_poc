using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Runtime.Validation;
using DemoCompany.DemoProject.Authorization.Users;
using FluentValidation;

namespace DemoCompany.DemoProject.Users.Dto
{
    [AutoMapTo(typeof(User))]
    public class CreateUserDto : IShouldNormalize
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public void Normalize()
        {
            if (RoleNames == null)
            {
                RoleNames = new string[0];
            }
        }
    }

    #region Tenant Wise Configure Rule Validation

    public class CreateUserDtoFluentValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoFluentValidator()
        {
            var configureRuleService = IocManager.Instance.Resolve<ConfigureRule.IConfigureRuleAppService>();
            //Same property to be configured in DB with Expression Table name : ConfigureRule
            var EmailAddressValidationRule = configureRuleService.GetEntityByRuleForProperty(CreateUserDtoConsts.RuleForProperty)?.SyntaxForProperty;

            if (!string.IsNullOrEmpty(EmailAddressValidationRule)) 
                RuleFor(x => x.EmailAddress).Matches(EmailAddressValidationRule);
        }
    }

    #endregion

    public class CreateUserDtoConsts
    {
        /// <summary>
        /// Same property to be configured in DB with Expression Table name : ConfigureRule
        /// </summary>
        public const string RuleForProperty = "Abp.Tenant.User.EmailAddress.RegEx";
    }
}
