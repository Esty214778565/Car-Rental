using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repository
{
    public class CarRepository : IRepository<CarEntity>
    {
        readonly DataContext _dataContext;
        public CarRepository(DataContext dataContext)
        { _dataContext = dataContext; }

        public List<CarEntity> GetAllData()
        {
            return _dataContext.Cars.ToList();
        }

        public CarEntity GetById(int id)
        {
            return _dataContext.Cars.ToList().Find(c => c.Id == id);
        }

        public bool Add(CarEntity car)
        {
            try
            {
                _dataContext.Cars.Add(car);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(CarEntity car)
        {
            int i = _dataContext.Cars.ToList().FindIndex(c => c.Id == car.Id);
            if (i < 0)
                return false;
            if (car.IsAvailable != _dataContext.Cars.ToList()[i].IsAvailable)
                _dataContext.Cars.ToList()[i].IsAvailable = car.IsAvailable;
            if (car.Test_validity != new DateTime())
                _dataContext.Cars.ToList()[i].Test_validity = car.Test_validity;
            if (car.Raiting != _dataContext.Cars.ToList()[i].Raiting)
                _dataContext.Cars.ToList()[i].Raiting = car.Raiting;
            if (car.Color != _dataContext.Cars.ToList()[i].Color)
                _dataContext.Cars.ToList()[i].Color = car.Color;
            if (car.Company != "")
                _dataContext.Cars.ToList()[i].Company = car.Company;
            if (car.Fuel_consumption_per_km > 0)
                _dataContext.Cars.ToList()[i].Fuel_consumption_per_km = car.Fuel_consumption_per_km;
            if (car.Kategory != _dataContext.Cars.ToList()[i].Kategory)
                _dataContext.Cars.ToList()[i].Kategory = car.Kategory;
            if (car.License_plate > 0)
                _dataContext.Cars.ToList()[i].License_plate = car.License_plate;
            if (car.Price > 0)
                _dataContext.Cars.ToList()[i].Price = car.Price;
            if (car.Model > 0)
                _dataContext.Cars.ToList()[i].Model = car.Model;
            if (car.Year_production > 0)
                _dataContext.Cars.ToList()[i].Year_production = car.Year_production;



            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public bool Delete(int id)
        {
            try
            {
                CarEntity c = _dataContext.Cars.ToList().Find(c => c.Id == id);
                _dataContext.Cars.Remove(c);
                _dataContext.SaveChanges();
                return true;
            }
            catch
            { return false; }
        }
        public int GetIndexById(int id)
        {
            return _dataContext.Cars.ToList().FindIndex(c => c.Id == id);
        }


    }
}
