using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarPooling.Domain;
using CarPooling.Web.ViewModels.Settings;
namespace CarPooling.Web.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<User, GeneralInformationViewModel>().ReverseMap();
        }
    }
}
