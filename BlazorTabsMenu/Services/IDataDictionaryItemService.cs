
namespace BlazorTabsMenu.Services
{
    public interface IDataDictionaryItemService<T>
    {
        List<T> Get();
        Task<List<T>> GetAsync();
        T? GetById(Guid id);
        //T Get(string name, int? tabNumber, string countryCode);
        T Add(T row);
        T InsertUpdate(T row);
        T Update(T row); T Delete(T row);
        void Save();
    }
}
