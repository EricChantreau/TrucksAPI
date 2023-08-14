using AutoMapper;
using TrucksAPI.Entities;
using TrucksAPI.Models.Trucks;

namespace TrucksAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequest, Truck>();

            CreateMap<UpdateRequest, Truck>().ForAllMembers(m => m.Condition((src, dest, prop) =>
            {
                // Ignore null & empty string values
                if (prop == null) return false;
                if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                return true;
            }));
        }
    }
}
