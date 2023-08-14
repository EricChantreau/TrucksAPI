using Microsoft.EntityFrameworkCore;
using TrucksAPI.Entities;

namespace TrucksAPI.Helpers
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            options.UseSqlite(_configuration.GetConnectionString("TrucksApiDatabase"));
        }

        public DbSet<Truck> Trucks { get; set; }
    }
}
