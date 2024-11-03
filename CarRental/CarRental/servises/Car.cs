namespace CarRental.servises
{
   public enum Raitings {a,b,c,d,e}
    public class Car
    {
        public int Id { get; set; }
        public int License_plate { get; set; }
        public int Model { get; set; }
        public string Company { get; set; }
        public int Year_production { get; set; }
        public int Fuel_consumption_per_km { get; set; }
        public DateOnly Test_validity { get; set; }
        public int Kategory { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }
        public int Color { get; set; }
        public Raitings Raiting { get; set; }


    }
}
