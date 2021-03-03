using Abp.AutoMapper;
using DemoCompany.DemoProject.Authentication.External;

namespace DemoCompany.DemoProject.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
