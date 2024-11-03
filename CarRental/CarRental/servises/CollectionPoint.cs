namespace CarRental.servises
{
    public class CollectionPoint
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public int Max_num_of_cars { get; set; }
        public int Num_of_cars_occupancy { get; set; }
        public bool Accessible_to_disabled { get; set; }
    }
}
