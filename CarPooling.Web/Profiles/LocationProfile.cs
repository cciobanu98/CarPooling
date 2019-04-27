using AutoMapper;
using CarPooling.Domain;
using CarPooling.Web.ViewModels.Settings;
using System.Linq;

namespace CarPooling.Web.Profiles
{
    public class LocationProfile : Profile
    {
        private string GetStringComma(string s, int i)
        {
            var token = s.Split(',');
            return token[i];
        }
        public LocationProfile()
        {
        }
    }
}
