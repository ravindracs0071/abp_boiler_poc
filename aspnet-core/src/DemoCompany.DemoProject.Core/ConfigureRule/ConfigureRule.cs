
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace DemoCompany.DemoProject.ConfigureRule
{
    public class ConfigureRule : AuditedEntity<long>, IMustHaveTenant
    {
        public const int MaxDescriptionLength = 1000;

        [StringLength(MaxDescriptionLength)]
        public virtual string RuleForProperty { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string SyntaxForProperty { get; set; }
        
        public virtual int TenantId { get; set; }
    }
}
