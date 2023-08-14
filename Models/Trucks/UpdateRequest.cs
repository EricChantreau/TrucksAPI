namespace TrucksAPI.Models.Trucks
{
    public class UpdateRequest
    {
        public string? LicensePlate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Mileage { get; set; }
    }
}
