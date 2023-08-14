using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrucksAPI.Entities;
using TrucksAPI.Helpers;

namespace TrucksAPI.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;

        public TruckRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Truck>> GetAll()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Truck?> GetById(long id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<Truck?> GetByVin(string vin)
        {
            return await _context.Trucks.FirstOrDefaultAsync(t => t.Vin == vin);
        }

        public async Task Add(Truck truck)
        {
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Truck truck)
        {
            Truck? foundTruck = await GetById(truck.Id);
            if (foundTruck == null) return;

            _context.Trucks.Update(truck);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(long id)
        {
            Truck? truck = await GetById(id);
            if (truck == null) return;

            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();
        }
    }
}
