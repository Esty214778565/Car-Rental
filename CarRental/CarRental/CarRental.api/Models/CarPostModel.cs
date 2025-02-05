using CarRental.Core.Entities;

namespace CarRental.api.Models
{
    public class CarPostModel
    {
        public int Id { get; set; }
        public int License_plate { get; set; }
        public int Model { get; set; }
        public string Company { get; set; }
        public int Year_production { get; set; }
        public int Fuel_consumption_per_km { get; set; }
        public DateTime Test_validity { get; set; }
        public Kategories Kategory { get; set; }
        public bool? IsAvailable { get; set; }
        public double Price { get; set; }
        public Colors Color { get; set; }
        public Raitings? Raiting { get; set; }
    }
}
