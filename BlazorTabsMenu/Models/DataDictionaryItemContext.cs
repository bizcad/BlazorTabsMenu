using Microsoft.EntityFrameworkCore;
using BlazorTabsMenu.Models;

namespace BlazorTabsMenu.Models
{
    public partial class  DataDictionaryItemContext : DbContext
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }

        public DataDictionaryItemContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataDictionaryItemContext(DbContextOptions<DataDictionaryItemContext> options)
            : base(options)
        {
            IConfigurationRoot builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("363d298d-ad40-47c2-85f4-10af1688f7dc")
                .Build();

            _connectionString = builder["ConnectionStrings:DockerDatabase"];
        }

        public DbSet<Models.DataDictionaryItem> DataDictionaryItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets("363d298d-ad40-47c2-85f4-10af1688f7dc")
                .Build();

            _connectionString = builder["ConnectionStrings:DockerDatabase"];

            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(_connectionString);                
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataDictionaryItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.QuestionNumber).HasMaxLength(10);
                entity.Property(e => e.CountryCode).HasMaxLength(2);
                entity.Property(e => e.DisplayTemplate).HasMaxLength(256);
            });
        }
    }

}
