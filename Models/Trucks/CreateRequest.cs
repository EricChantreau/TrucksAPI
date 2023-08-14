using System.ComponentModel.DataAnnotations;
using TrucksAPI.Entities;

namespace TrucksAPI.Models.Trucks
{
    public class CreateRequest
    {
        [Required]
        [StringLength(14)]
        public string? Vin { get; set; }

        [Required]
        [EnumDataType(typeof(Model))]
        public string? Model { get; set; }

        [Required]
        public string? LicensePlate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public double Mileage { get; set; }
    }
}
