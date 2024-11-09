namespace CarRental.Entity
{
    public class DataContextManager
    {
      public static DataContext DataContext { get; set; }= new DataContext();
        public DataContextManager()
        {
               
        }
    }
}
