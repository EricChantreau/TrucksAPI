using AutoMapper;
using TrucksAPI.Entities;
using TrucksAPI.Models.Trucks;
using TrucksAPI.Repositories;

namespace TrucksAPI.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _repository;
        private readonly IMapper _mapper;

        public TruckService(ITruckRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Truck>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Truck> GetById(long id)
        {
            Truck? truck = await _repository.GetById(id);
            if (truck == null) throw new KeyNotFoundException("Truck not found");

            return truck;
        }

        public async Task<Truck> GetByVin(string vin)
        {
            Truck? truck = await _repository.GetByVin(vin);
            if (truck == null) throw new ApplicationException("Truck not found");

            return truck;
        }

        public async Task Add(CreateRequest model)
        {
            if (await _repository.GetByVin(model.Vin!) != null) throw new ApplicationException($"Truck with vin '{model.Vin}' already exists");

            Truck truck = _mapper.Map<Truck>(model);
            await _repository.Add(truck);
        }

        public async Task Update(long id, UpdateRequest model)
        {
            Truck? truck = await _repository.GetById(id);
            if (truck == null) throw new KeyNotFoundException("Truck not found");

            _mapper.Map(model, truck);
            await _repository.Update(truck);
        }

        public async Task DeleteById(long id)
        {
            await _repository.DeleteById(id);
        }
    }
}
