namespace CarRental.Entity
{
    public class DataContext
    {
        public List<Car> Cars { get; set; }
        public List<CollectionPoint> CollectionPoints { get; set; }
        public List<Invitation> Invitations { get; set; }
        public List<User> Users { get; set; }

        public DataContext()
        {
                Cars = new List<Car>();
            CollectionPoints = new List<CollectionPoint>(); 
            Invitations = new List<Invitation>();   
            Users = new List<User>();
        }
    }
}
