using TrucksAPI.Entities;

namespace TrucksAPI.Helpers
{
    public class RandomGenerator
    {
        private const string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int VIN_LENGTH = 14;
        private static readonly DateTime START_DATE = new DateTime(2020, 1, 1);
        private const int MAX_MILEAGE = 500000;

        private static readonly Random _random = new Random();

        public static string GetString(int length)
        {
            return new string(Enumerable.Repeat(CHARACTERS, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public static string GetVin()
        {
            return GetString(VIN_LENGTH);
        }

        public static string GetLicensePlate()
        {
            return $"{GetString(2)}-{GetString(3)}-{GetString(2)}";
        }

        public static Model GetModel()
        {
            var values = Enum.GetValues(typeof(Model));

            return (Model)values.GetValue(_random.Next(values.Length))!;
        }

        public static DateTime GetDateTime()
        {
            int range = (DateTime.Today - START_DATE).Days;

            return START_DATE.AddDays(_random.Next(range));
        }

        public static double GetMileage()
        {
            return Math.Floor(_random.NextDouble() * _random.Next(MAX_MILEAGE) * 100) / 100;
        }
    }
}
