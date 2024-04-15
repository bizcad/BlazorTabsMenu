using BlazorTabsMenu.Models;

namespace BlazorTabsMenu.Services
{
    public interface ITopicService : IWiplService<Models.Topic>
    {
        Task<List<Topic>> GetSortedAsync();
        Task<Topic> GetTabNumberAsync(int tabnumber);


    }
}
