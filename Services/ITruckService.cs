using Microsoft.AspNetCore.Mvc.Infrastructure;
using TrucksAPI.Entities;
using TrucksAPI.Models.Trucks;

namespace TrucksAPI.Services
{
    public interface ITruckService
    {
        Task<IEnumerable<Truck>> GetAll();
        Task<Truck> GetById(long id);
        Task<Truck> GetByVin(string vin);
        Task Add(CreateRequest model);
        Task Update(long id, UpdateRequest model);
        Task DeleteById(long id);
    }
}
