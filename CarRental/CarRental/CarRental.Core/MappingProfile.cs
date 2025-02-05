
using AutoMapper;
using CarRental.Core.DTOs;
using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //DTO
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<CarEntity, CarDto>().ReverseMap();
            CreateMap<CollectionPointEntity, CollectionPointDto>().ReverseMap();
            CreateMap<InvitationEntity, InvitationDto>().ReverseMap();

            //POST MODEL


        }
    }
}
