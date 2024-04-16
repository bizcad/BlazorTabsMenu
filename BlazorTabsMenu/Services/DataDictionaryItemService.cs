using BlazorTabsMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services
{
    public class DataDictionaryItemService : IDataDictionaryItemService<Models.DataDictionaryItem>
    {
        private readonly DataDictionaryItemContext _context;
        public DataDictionaryItemService()
        {
            //string? userSecretsId = "ConnectionStrings.DockerDatabase";
            //IConfigurationRoot config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddUserSecrets(userSecretsId)
            //    .Build();

            //string? connectionString = "Data Source=localhost,11433;Initial Catalog=WIPL;User ID=sa;Password=usPjGL#d;";

            //if (connectionString == null)
            //{
            //    throw new InvalidOperationException("Connection string not found.");
            //}

            _context = new DataDictionaryItemContext();
        }


        public DataDictionaryItemService(DataDictionaryItemContext context)
        {
            _context = context;
        }

        /****************************
        * 
        //Implement the IDataDictionaryItemService interface
        *
        ****************************/
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
        async Task<List<DataDictionaryItem>> IDataDictionaryItemService<DataDictionaryItem>.GetTabNumberAsync(int tabNumber)
        {
            //return _context.Topic.OrderBy(x => x.TabNumber).ToListAsync();
            return await  _context.DataDictionaryItem
                .Where(x => x.TabNumber == tabNumber)
                .OrderBy(x => x.Sequence)
                .ToListAsync();
        }
    }
}
