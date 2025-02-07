using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.IService
{
    public interface ICarService
    {
        List<CarDto> GetCarList();
        CarDto GetCarById(int id);
        bool Add(CarDto car);
        bool Update(CarDto car);
        bool Delete(int id);

    }
}
