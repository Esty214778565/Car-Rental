using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using System.Runtime.CompilerServices;

namespace CarRental.Service
{
    public class CarService : ICarService
    {

       
        readonly IRepository<CarEntity> _CarRepository;
        readonly IMapper _mapper;
        
        public CarService(IRepository<CarEntity> carRepository,IMapper mapper)
        {
            _CarRepository = carRepository;
            _mapper = mapper;
        }
     
            

        public List<CarDto> GetCarList()
        {
            var list= _CarRepository.GetAllDataAsync();
            var listDto=_mapper.Map<IEnumerable<CarDto>>(list);
            return listDto.ToList(); 
        }

        public CarDto GetCarById(int id)
        {
            var car= _CarRepository.GetById(id);
            return _mapper.Map<CarDto>(car);
        }

        public bool Add(CarDto Car)
        {
            if(_CarRepository.GetIndexById(Car.Id)>-1) 
                return false;
            return _CarRepository.Add(_mapper.Map<CarEntity>(Car));
        }

        public bool Update(CarDto Car)
        {
            if (_CarRepository.GetIndexById(Car.Id)<0)
                return false;
            return _CarRepository.Update(_mapper.Map<CarEntity>(Car));
        }

        public bool Delete(int id)
        {
            if (_CarRepository.GetIndexById(id)<0)
                return false;
            return _CarRepository.Delete(id);
        }

    }

}
