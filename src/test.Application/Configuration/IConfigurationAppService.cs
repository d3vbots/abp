using test.Configuration.Dto;
using System.Threading.Tasks;

namespace test.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
