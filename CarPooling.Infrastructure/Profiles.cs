using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPooling.Domain;
using CarPooling.DTO;

namespace CarPooling.Infrastructure
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Ride, RideDTO>().ReverseMap();
            CreateMap<Ride, SelectedRidesDTO>().ReverseMap();
            CreateMap<Car, CarInformationDTO>().ReverseMap();
            CreateMap<User, GeneralInformationDTO>().ReverseMap();
            CreateMap<Request, RequestDTO>().
                ForMember(dest => dest.Requester, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
