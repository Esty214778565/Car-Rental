using Microsoft.AspNetCore.Mvc;

namespace CarRental.servises
{
    public class CarServise
    {
        public List<Car> Cars { get; set; }
        public CarServise()
        {
            Cars= new List<Car>();
         
        }
        public List<Car> getCars()
        {
            return Cars;
        }

        public Car GetCarById(int id)
        {
            return Cars.Find(car => car.Id == id);
        }

        public bool PutCar(int id,Car car)
        {
            Car ca = Cars.Find(c => c.Id ==id);
            if (ca == null) 
                return false;
            Cars.Remove(ca);
            Cars.Add(car);
            return true;
        }
        public bool PostCar(Car car)
        {
            Cars.Add(car);
            return true;
        }
        public bool DeleteCar(int id)
        {
            Car car=Cars.Find(i=>i.Id==id);
            if (car == null)
                return false;
            Cars.Remove(car);
            return true;
        }


    }
}
