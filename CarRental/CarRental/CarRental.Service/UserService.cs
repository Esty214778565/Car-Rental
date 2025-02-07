using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{

    public class UserService : IUserService
    {
        readonly IRepository<UserEntity> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        public List<UserDto> GetUserList()
        {
            var list=_userRepository.GetAllDataAsync();
            var listDto = _mapper.Map<IEnumerable<UserDto>>(list);
            return listDto.ToList();
        }

        public UserDto GetUserById(int id)
        {
            var user= _userRepository.GetById(id);
            return _mapper.Map<UserDto>(user);
        }

        public bool Add(UserDto user)
        {
            if (_userRepository.GetIndexById(user.Id) > -1)
                return false;
            if (!IsValidIsraelTz(user.Tz) || !IsValidEmail(user.Email))
                return false;
            return _userRepository.Add(_mapper.Map<UserEntity>(user));
        }

        public bool Update(UserDto user)
        {
            if (_userRepository.GetIndexById(user.Id) < 0)
                return false;
            if (!IsValidIsraelTz(user.Tz) || !IsValidEmail(user.Email))
                return false;
            return _userRepository.Update(_mapper.Map<UserEntity>(user));
        }

        public bool Delete(int id)
        {
            if (_userRepository.GetIndexById(id) < 0)
                return false;
            return _userRepository.Delete(id);
        }

        public bool IsValidIsraelTz(string id)
        {
            id = id.Trim();
            if (id.Length > 9 || !int.TryParse(id, out _))
                return false;
            id = id.Length < 9 ? ("00000000" + id).Substring(id.Length) : id;
            return id.Select(c => int.Parse(c.ToString()))
                     .Select((digit, i) => digit * (i % 2 + 1))
                     .Sum(step => step > 9 ? step - 9 : step) % 10 == 0;
        }
        public bool IsValidEmail(string email)
        {
            int i = email.LastIndexOf('@');
            int j = email.LastIndexOf('.');
            return i != -1 && j != -1 && i < j;
        }

    }
}
