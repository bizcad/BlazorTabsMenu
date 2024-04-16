using BlazorTabsMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services
{
    public interface ITopicService : IWiplService<Models.Topic>
    {
        Task<List<Topic>> GetSortedAsync();
        Task<Topic?> GetTabNumberAsync(int tabnumber);
        Task<List<Topic>> GetSurveyTopicsAsync();
        Task<Topic?> GetSurveyTopicAsync(int topicnumber);


    }
}
