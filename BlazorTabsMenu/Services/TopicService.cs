using BlazorTabsMenu.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace BlazorTabsMenu.Services
{
    public class TopicService : ITopicService
    {
        private readonly TopicContext _context;
        public TopicService()
        {
            //IConfigurationRoot builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddUserSecrets("363d298d-ad40-47c2-85f4-10af1688f7dc")
            //    .Build();

            //string connectionString = builder["ConnectionStrings:DockerDatabase"];

            //_context = new TopicContext(connectionString);
            _context = new TopicContext();
        }
        //public TopicService(TopicContext context)
        //{
        //    _context = context;
        //}   
        //public TopicService(string? connectionString)
        //{
        //    _ = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddUserSecrets("363d298d-ad40-47c2-85f4-10af1688f7dc")
        //        .Build();

        //    //string connectionString = builder["ConnectionStrings:DockerDatabase"];
        //    if(string.IsNullOrEmpty(connectionString))
        //    {
        //        throw new Exception("No connection string found in appsettings.json or user secrets");
        //    }
        //    else
        //    {               
        //        _context = new TopicContext(connectionString);
        //    }
        //}


        //Implement the IWiplService interface
        public List<Models.Topic> Get()
        {
            return [.. _context.Topic];
        }
        public Models.Topic? GetById(Guid id)
        {
            var row = _context.Topic.Find(id);
            if (row != null)
            {
                return row;
            }
            else
            {
                return null;
            }
        }
        public Models.Topic Add(Models.Topic row)
        {
            _context.Topic.Add(row);
            return row;
        }
        public Models.Topic InsertUpdate(Models.Topic row)
        {
            if (row.Id == Guid.Empty)
            {
                _context.Topic.Add(row);
            }
            else
            {
                _context.Topic.Update(row);
            }
            return row;
        }
        public Models.Topic Update(Models.Topic row)
        {
            _context.Topic.Update(row);
            return row;
        }
        public Models.Topic Delete(Models.Topic row)
        {
            _context.Topic.Remove(row);
            return row;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void DeleteAll()
        {
            _context.Topic.RemoveRange(_context.Topic);
            _context.SaveChanges();
        }
        public void Delete(Guid id)
        {
            var row = _context.Topic.Find(id);
            if (row != null)
            {
                _context.Topic.Remove(row);
                _context.SaveChanges();
            }
        }
        public async Task<List<Topic>> GetAsync()
        {
            return await _context.Topic.ToListAsync();
        }

        Task<List<Topic>> ITopicService.GetSortedAsync()
        {
            return _context.Topic.OrderBy(x => x.TabNumber).ToListAsync();
        }

        Task<Topic> ITopicService.GetTabNumberAsync(int tabnumber)
        {
            return _context.Topic.Where(x => x.TabNumber == tabnumber).FirstOrDefaultAsync();

        }

        async Task<List<Topic>> ITopicService.GetSurveyTopicsAsync()
        {

            var topics = await _context.Topic
                .Where(t => t.TabNumber > 0 && t.TabNumber < 7)
                .OrderBy(t => t.TabNumber)
                .ToListAsync();

            return topics;
        }
    }
}
