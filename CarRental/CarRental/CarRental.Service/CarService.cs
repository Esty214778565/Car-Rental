using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;

namespace CarRental.Service
{
    public class CarService : ICarService
    {

       
        readonly IRepository<CarEntity> _CarRepository;
        
        public CarService(IRepository<CarEntity> carRepository)
        {
            _CarRepository = carRepository;
        }
     
            

        public List<CarEntity> GetCarList()
        {
            return _CarRepository.GetAllData();
        }

        public CarEntity GetCarById(int id)
        {
            return _CarRepository.GetById(id);
        }

        public bool Add(CarEntity Car)
        {
            if(_CarRepository.GetIndexById(Car.Id)>-1) 
                return false;
            return _CarRepository.Add(Car);
        }

        public bool Update(CarEntity Car)
        {
            if (_CarRepository.GetIndexById(Car.Id)<0)
                return false;
            return _CarRepository.Update(Car);
        }

        public bool Delete(int id)
        {
            if (_CarRepository.GetIndexById(id)<0)
                return false;
            return _CarRepository.Delete(id);
        }

    }

}
