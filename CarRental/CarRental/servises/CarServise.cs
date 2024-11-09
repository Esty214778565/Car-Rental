using CarRental.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.servises
{
    public class CarServise
    {
        public CarServise()
        {
        }
        public List<Car> getCars()
        {
            if (DataContextManager.DataContext.Cars == null)
                DataContextManager.DataContext.Cars = new List<Car>();
            return DataContextManager.DataContext.Cars;
        }

        public Car GetCarById(int id)
        {   
            return DataContextManager.DataContext.Cars.Find(car => car.Id == id);
        }

        public bool Update(int id,Car car)
        {
            Car ca = DataContextManager.DataContext.Cars.Find(c => c.Id ==id);
            if (ca == null) 
                return false;
            DataContextManager.DataContext.Cars.Remove(ca);
            DataContextManager.DataContext.Cars.Add(car);
            return true;
        }
        public bool Add(Car car)
        {
            if(DataContextManager.DataContext.Cars ==null)
              DataContextManager.DataContext.Cars = new List<Car>();
            DataContextManager.DataContext.Cars.Add(car);
            return true;
        }
        public bool DeleteCar(int id)
        {
            Car car= DataContextManager.DataContext.Cars.Find(i=>i.Id==id);
            if (car == null)
                return false;
            DataContextManager.DataContext.Cars.Remove(car);
            return true;
        }
        


    }
}
