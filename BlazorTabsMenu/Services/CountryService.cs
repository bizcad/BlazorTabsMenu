using BlazorTabsMenu.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services
{
    public class CountryService : ICountryService
    {
        private readonly CountryContext _context;
        public CountryService()
        {
            _context = new CountryContext();
        }

        //Implement the IWiplService interface
        public List<Models.Country> Get()
        {
            return [.. _context.Country];
        }
        public Models.Country? GetById(Guid id)
        {
            var row = _context.Country.Find(id);
            if (row != null)
            {
                return row;
            }
            else
            {
                return null;
            }
        }
        public Models.Country Add(Models.Country row)
        {
            _context.Country.Add(row);
            return row;
        }
        public Models.Country InsertUpdate(Models.Country row)
        {
            if (row.Id == 0)
            {
                _context.Country.Add(row);
            }
            else
            {
                _context.Country.Update(row);
            }
            return row;
        }
        public Models.Country Update(Models.Country row)
        {
            _context.Country.Update(row);
            return row;
        }
        public Models.Country Delete(Models.Country row)
        {
            _context.Country.Remove(row);
            return row;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Country.RemoveRange(_context.Country);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var row = _context.Country.Find(id);
            if (row != null)
            {
                _context.Country.Remove(row);
                _context.SaveChanges();
            }
        }
        public async Task<List<Country>> GetAsync()
        {
            return await _context.Country.ToListAsync();
        }

        //Task<List<Country>> ICountryService.GetSortedAsync()
        //{
        //    return _context.Country.OrderBy(x => x.TabNumber).ToListAsync();
        //}

        //Task<Country> ICountryService.GetTabNumberAsync(int tabnumber)
        //{
        //    return _context.Country.Where(x => x.TabNumber == tabnumber).FirstOrDefaultAsync();

        //}
    }
}
