using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;


namespace DemoCompany.DemoProject.ConfigureRule.Dto
{
    [AutoMapTo(typeof(ConfigureRule))]
    public class EditConfigureRuleDto
    {
        [Required]
        public virtual long Id { get; set; }

        public const int MaxDescriptionLength = 1000;

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string RuleForProperty { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public virtual string SyntaxForProperty { get; set; }
    }
}
