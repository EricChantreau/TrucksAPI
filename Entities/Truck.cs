namespace TrucksAPI.Entities
{
    public class Truck
    {
        public long Id { get; set; }
        public string? Vin { get; set; }
        public Model Model { get; set; }
        public string? LicensePlate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Mileage { get; set; }
    }
}
