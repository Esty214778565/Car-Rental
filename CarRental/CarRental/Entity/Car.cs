namespace CarRental.Entity
{
    public enum Raitings { a, b, c, d, e }
    public class Car
    {
        public Car()
        {
        }

        public int Id { get; set; }
        public int License_plate { get; set; }
        public int Model { get; set; }
        public string Company { get; set; }
        public int Year_production { get; set; }
        public int Fuel_consumption_per_km { get; set; }
        public DateTime Test_validity { get; set; }
        public int Kategory { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }
        public int Color { get; set; }
        public Raitings Raiting { get; set; }

        public Car(int id, int license_plate, int model, string company, int year_production, int fuel_consumption_per_km, DateTime test_validity, int kategory, bool isAvailable, double price, int color, Raitings raiting)
        {
            Id = id;
            License_plate = license_plate;
            Model = model;
            Company = company;
            Year_production = year_production;
            Fuel_consumption_per_km = fuel_consumption_per_km;
            Test_validity = test_validity;
            Kategory = kategory;
            IsAvailable = isAvailable;
            Price = price;
            Color = color;
            Raiting = raiting;
        }
    }
}
