using System.Threading.Tasks;
using DemoCompany.DemoProject.Configuration.Dto;

namespace DemoCompany.DemoProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
