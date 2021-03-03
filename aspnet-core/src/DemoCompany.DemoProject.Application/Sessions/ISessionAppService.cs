using System.Threading.Tasks;
using Abp.Application.Services;
using DemoCompany.DemoProject.Sessions.Dto;

namespace DemoCompany.DemoProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
