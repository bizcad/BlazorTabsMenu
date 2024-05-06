using BlazorTabsMenu.Models;

namespace BlazorTabsMenu.Services
{
    public interface IInformationSchemaColumnService 
    {
        List<InformationSchemaColumn> Get();
        Task<List<InformationSchemaColumn>> GetAsync();
    }
}
