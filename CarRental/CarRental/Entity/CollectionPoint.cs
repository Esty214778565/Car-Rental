namespace CarRental.Entity
{
    public class CollectionPoint
    {
        public CollectionPoint()
        {
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int Max_num_of_cars { get; set; }
        public int Num_of_cars_occupancy { get; set; }
        public bool Accessible_to_disabled { get; set; }

        public CollectionPoint(int id, string city, string adress, int max_num_of_cars, int num_of_cars_occupancy, bool accessible_to_disabled)
        {
            Id = id;
            City = city;
            Adress = adress;
            Max_num_of_cars = max_num_of_cars;
            Num_of_cars_occupancy = num_of_cars_occupancy;
            Accessible_to_disabled = accessible_to_disabled;
        }
    }
}
