using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.IService
{
    public interface IUserService
    {
        List<UserDto> GetUserList();
        UserDto GetUserById(int id);
        bool Add(UserDto user);
        bool Update(UserDto user);
        bool Delete(int id);
    }
}
