using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarPooling.Domain;
using CarPooling.Web.ViewModels.Settings;

namespace CarPooling.Web.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarInformationViewModel>().ReverseMap();
        }
    }
}
