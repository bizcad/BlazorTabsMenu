using BlazorTabsMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services
{
    public class DataDictionaryItemService : IDataDictionaryItemService<Models.DataDictionaryItem>
    {
        private readonly DataDictionaryItemContext _context;
        public DataDictionaryItemService()
        {
            IConfigurationRoot builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("363d298d-ad40-47c2-85f4-10af1688f7dc")
                .Build();

            string connectionString = builder["ConnectionStrings:DockerDatabase"];

            _context = new DataDictionaryItemContext(connectionString);
        }
        public DataDictionaryItemService(DataDictionaryItemContext context)
        {
            _context = context;
        }

        //Implement the IDataDictionaryItemService interface
        public List<Models.DataDictionaryItem> Get()
        {
            return [.. _context.DataDictionaryItem];
        }
        public Models.DataDictionaryItem? GetById(Guid id)
        {
            var row = _context.DataDictionaryItem.Find(id);
            if (row != null)
            {
                return row;
            }
            else
            {
                return null;
            }
        }
        public Models.DataDictionaryItem Add(Models.DataDictionaryItem row)
        {
            _context.DataDictionaryItem.Add(row);
            return row;
        }
        public Models.DataDictionaryItem InsertUpdate(Models.DataDictionaryItem row)
        {
            if (row.Id == Guid.Empty)
            {
                _context.DataDictionaryItem.Add(row);
            }
            else
            {
                _context.DataDictionaryItem.Update(row);
            }
            return row;
        }
        public Models.DataDictionaryItem Update(Models.DataDictionaryItem row)
        {
            _context.DataDictionaryItem.Update(row);
            return row;
        }
        public Models.DataDictionaryItem Delete(Models.DataDictionaryItem row)
        {
            _context.DataDictionaryItem.Remove(row);
            return row;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<List<DataDictionaryItem>> GetAsync()
        {
            return await _context.DataDictionaryItem.ToListAsync();
        }
    }
}
