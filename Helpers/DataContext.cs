using Microsoft.EntityFrameworkCore;
using TrucksAPI.Entities;

namespace TrucksAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            options.UseInMemoryDatabase("TestDb");
        }

        public DbSet<Truck> Trucks { get; set; }
    }
}
