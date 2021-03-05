using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Runtime.Validation;
using FluentValidation;

namespace DemoCompany.DemoProject.ConfigureRule.Dto
{
    [AutoMapTo(typeof(ConfigureRule))]
    public class CreateConfigureRuleDto
    {
        public const int MaxDescriptionLength = 1000;

        [StringLength(MaxDescriptionLength)]
        public virtual string RuleForProperty { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string SyntaxForProperty { get; set; }

        #region Custom Validator
        //ICustomValidate
        //public void AddValidationErrors(CustomValidationContext context)
        //{
        //    var x = context.IocResolver.Resolve<IAbpSession>().GetUserId();
        //    var localization = context.IocResolver
        //       .Resolve<ILocalizationManager>();
        //    var z = localization.GetString(DemoProjectConsts.LocalizationSourceName, "HomePage");
        //    if (AssignedTenant.HasValue && (AssignedTenant.Value == 0 || AssignedTenant.Value == 1))
        //    {
        //        context.Results.Add(new ValidationResult("AssignedTenant must be set 2, 3, 4!"));
        //    }
        //}
        #endregion

        #region Fluent Validation
        //public class CreateSampleTaskDtoValidator : AbstractValidator<CreateConfigureRuleDto>
        //{
        //    public CreateSampleTaskDtoValidator()
        //    {
        //        var localization = IocManager.Instance.Resolve<ILocalizationManager>();
        //        var z = localization.GetString(DemoProjectConsts.LocalizationSourceName, "HomePage");
        //        RuleFor(x => x.DisplayName).Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        //    }
        //}
        #endregion
    }
}
