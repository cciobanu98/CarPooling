using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarPooling.Domain;
using CarPooling.Web.ViewModels.Settings;
using CarPooling.Web.ViewModels;
namespace CarPooling.Web.Profiles
{
    public class RideProfile : Profile
    {
        public RideProfile()
        {
            CreateMap<Ride, RideViewModel>();
            CreateMap<Ride, LastRideViewModel>();
        }
    }
}
