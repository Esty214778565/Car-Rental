using AutoMapper;
using CarRental.api.Models;
using CarRental.Core.DTOs;

namespace CarRental.api
{
    public class MappingProfilePostModel:Profile
    {
        public MappingProfilePostModel()
        {
            CreateMap<UserDto,UserPostModel>();
            CreateMap<CarDto,CarPostModel>();
            CreateMap<CollectionPointDto,CollectionPointPostModel>();
            CreateMap<InvitationDto,InvitationPostModel>();

        }
    }
}
