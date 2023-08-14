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

        public async Task Init()
        {
            if (Trucks.Any()) return;

            const int trucksNumber = 50;
            for (int i = 0; i < trucksNumber; i++)
            {
                Trucks.Add(new Truck()
                {
                    Vin = RandomGenerator.GetVin(),
                    LicensePlate = RandomGenerator.GetLicensePlate(),
                    Model = RandomGenerator.GetModel(),
                    StartDate = RandomGenerator.GetDateTime(),
                    Mileage = RandomGenerator.GetMileage(),
                });
            }

            await SaveChangesAsync();
        }
    }
}
