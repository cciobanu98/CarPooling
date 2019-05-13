using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPooling.Domain;
using CarPooling.DTO;
using System.Linq;
using CarPooling.Helpers;

namespace CarPooling.Infrastructure
{

    public class CustomDestination : IValueResolver<Ride, SelectedRidesWithDistanceDTO, float>
    {
        public float Resolve(Ride source, SelectedRidesWithDistanceDTO destination, float destMember, ResolutionContext context)
        {
            SelectRideDTO selectRide = context.Items["SelectRide"] as SelectRideDTO;
            Coordinates s1 = new Coordinates(source.DestinationLocation.Latitude, source.DestinationLocation.Longitude);
            Coordinates s2 = new Coordinates(selectRide.DestinationLocationLat, selectRide.DestinationLocationLng);
            
            return Algo.GetDistanceInKm(s1, s2);
        }
    }
    public class CustomSource : IValueResolver<Ride, SelectedRidesWithDistanceDTO, float>
    {
        public float Resolve(Ride source, SelectedRidesWithDistanceDTO destination, float destMember, ResolutionContext context)
        {
            SelectRideDTO selectRide = context.Items["SelectRide"] as SelectRideDTO;
            Coordinates s1 = new Coordinates(source.SourceLocation.Latitude, source.SourceLocation.Longitude);
            Coordinates s2 = new Coordinates(selectRide.SourceLocationLat, selectRide.SourceLocationLng);
            return Algo.GetDistanceInKm(s1, s2);
        }
    }
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Ride, RideDTO>().ReverseMap();
            CreateMap<Ride, SelectedRidesDTO>()
               .ForMember(dest => dest.Destination, opt => opt.MapFrom(x => x.DestinationLocation.City))
               .ForMember(dest => dest.Source, opt => opt.MapFrom(x => x.SourceLocation.City))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Car.User.UserName));
            CreateMap<Ride, SelectedRidesWithDistanceDTO>()
               .ForMember(dest => dest.Destination, opt => opt.MapFrom(x => x.DestinationLocation.City))
               .ForMember(dest => dest.Source, opt => opt.MapFrom(x => x.SourceLocation.City))
               .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.Car.User.UserName))
               .ForMember(dest => dest.SourceLatitude, opt => opt.MapFrom(x => x.SourceLocation.Latitude))
               .ForMember(dest => dest.SourceLongitude, opt => opt.MapFrom(x => x.SourceLocation.Longitude))
               .ForMember(dest => dest.DestinationLatitude, opt => opt.MapFrom(x => x.DestinationLocation.Latitude))
               .ForMember(dest => dest.DestinationLongitude, opt => opt.MapFrom(x => x.DestinationLocation.Longitude))
               .ForMember(dest => dest.DistanceFromSource, opt => opt.MapFrom(new CustomSource()))
               .ForMember(dest => dest.DistanceFromDestination, opt => opt.MapFrom(new CustomDestination()));
            CreateMap<Car, CarInformationDTO>().ReverseMap();
            CreateMap<User, GeneralInformationDTO>().ReverseMap();
            CreateMap<Request, RequestDTO>().
                ForMember(dest => dest.Requester, opt => opt.MapFrom(src => src.UserId));
            CreateMap<Rating, RatingDTO>().ReverseMap();
            CreateMap<Rating, RatingLeftDTO>().
                ForMember(dest => dest.LeftFor, opt => opt.MapFrom(src => src.Ride.Car.User.UserName))
                .ForMember(dest => dest.RatingId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Rating, RatingReceivedDTO>()
                .ForMember(dest => dest.ReceivedFrom, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<Ride, EnroledRideDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TravelStartDateTime))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.SourceLocation.City))
                .ForMember(dest => dest.Where, opt => opt.MapFrom(src => src.DestinationLocation.City))
                .ForMember(dest => dest.PassengersName, opt => opt.MapFrom(src => src.Passengers.Select(x => x.User.UserName).ToArray()))
                .ForMember(dest => dest.PassengersId, opt => opt.MapFrom(src => src.Passengers.Select(x => x.User.Id).ToArray()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Rider, opt => opt.MapFrom(src => src.Car.User.UserName))
                .ForMember(dest => dest.RideId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Ride, OfferedRideDTO>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TravelStartDateTime))
                .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.SourceLocation.City))
                .ForMember(dest => dest.Where, opt => opt.MapFrom(src => src.DestinationLocation.City))
                .ForMember(dest => dest.PassengersName, opt => opt.MapFrom(src => src.Passengers.Select(x => x.User.UserName).ToArray()))
                .ForMember(dest => dest.PassengersId, opt => opt.MapFrom(src => src.Passengers.Select(x => x.User.Id).ToArray()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Ride, RideInformationDTO>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Car.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Car.User.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Car.User.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Car.User.Email))
                .ForMember(dest => dest.CarColor, opt => opt.MapFrom(src => src.Car.Color))
                .ForMember(dest => dest.CarNumber, opt => opt.MapFrom(src => src.Car.Number))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.SourceAddress, opt => opt.MapFrom(src => src.SourceLocation.Street))
                .ForMember(dest => dest.SourceCity, opt => opt.MapFrom(src => src.SourceLocation.City))
                .ForMember(dest => dest.SourceState, opt => opt.MapFrom(src => src.SourceLocation.Country))
                .ForMember(dest => dest.DestinationAddress, opt => opt.MapFrom(src => src.DestinationLocation.Street))
                .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.DestinationLocation.City))
                .ForMember(dest => dest.DestinationState, opt => opt.MapFrom(src => src.DestinationLocation.Country))
                .ForMember(dest => dest.SourceLat, opt => opt.MapFrom(src => src.SourceLocation.Latitude))
                .ForMember(dest => dest.SourgeLng, opt => opt.MapFrom(src => src.SourceLocation.Longitude))
                .ForMember(dest => dest.DestinationLat, opt => opt.MapFrom(src => src.DestinationLocation.Latitude))
                .ForMember(dest => dest.DestinationLng, opt => opt.MapFrom(src => src.DestinationLocation.Longitude))
                .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.Passengers))
                .ForMember(dest => dest.RideId, opt => opt.MapFrom(src => src.Id));
            CreateMap<RideDTO, Ride>()
                .ForMember(dest => dest.SourceLocation, opt => opt.MapFrom(src => new Location
                {
                    Latitude = src.SourceLocationLat,
                    Longitude = src.SourceLocationLng,
                    Street = src.SourceStreet,
                    City = src.SourceCity,
                    Country = src.SourceState
                }))
                 .ForMember(dest => dest.DestinationLocation, opt => opt.MapFrom(src => new Location
                 {
                     Latitude = src.DestinationLocationLat,
                     Longitude = src.DestinationLocationLng,
                     Street = src.DestinationStreet,
                     City = src.DestinationCity,
                     Country = src.DestinationState
                 }))
                 .ForMember(dest => dest.TravelStartDateTime, opt => opt.MapFrom(src => src.TravelStartDate));
        }
    }
}
