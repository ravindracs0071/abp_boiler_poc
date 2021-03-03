using Abp.Application.Services.Dto;

namespace DemoCompany.DemoProject.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

