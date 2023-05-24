using System.Threading.Tasks;
using QualisTechnologiesCurpSolution.Configuration.Dto;

namespace QualisTechnologiesCurpSolution.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
