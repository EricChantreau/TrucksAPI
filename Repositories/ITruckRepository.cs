using TrucksAPI.Entities;

namespace TrucksAPI.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetAll();
        Task<Truck?> GetById(long id);
        Task<Truck?> GetByVin(string vin);
        Task Add(Truck truck);
        Task Update(Truck truck);
        Task DeleteById(long id);
    }
}
