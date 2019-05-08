using System;
using System.Collections.Generic;
using System.Text;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using System.Linq;
using CarPooling.DTO;
using CarPooling.Domain;
using CarPooling.Context;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.BussinesLogic.Services
{
    public class RideService : IRideService
    {
        private readonly IUnitOfWork _uow;
        private readonly CarPoolingContext _context;
        public RideService(IUnitOfWork uow, CarPoolingContext context)
        {
            _uow = uow;
            _context = context;
        }
        public void AddPassengerToRide(int rideId, string passengerId)
        {
            var User = _uow.UsersRepository.Get((x => x.Id == passengerId)).SingleOrDefault();
            var Ride = _uow.RidesRepository.Get((x => x.Id == rideId), includeProperties: "Passengers").SingleOrDefault();
            Ride.Passengers.Add(User);
            Ride.Seats--;
            //Add Error of Seats
            _uow.RidesRepository.Update(Ride);
            _uow.Save();
        }
        public void AddRide(RideDTO RideToAdd)
        {
            //use automapper
            Ride ride = new Ride();
            Location source = new Location();
            Location destination = new Location();
            source.Latitude = RideToAdd.SourceLocationLat;
            source.Longitude = RideToAdd.SourceLocationLng;
            source.Street = RideToAdd.SourceStreet;
            source.City = RideToAdd.SourceCity;
            source.Country = RideToAdd.SourceState;
            destination.Street = RideToAdd.DestinationStreet;
            destination.City = RideToAdd.DestinationCity;
            destination.Country = RideToAdd.DestinationState;
            ride.CreatedDateTime = DateTime.Now;
            ride.SourceLocation = source;
            ride.DestinationLocation = destination;
            ride.TravelStartDateTime = Convert.ToDateTime(RideToAdd.TravelStartDateTime);
            ride.Price = 20;
            ride.Car = _uow.CarsRepository.GetById(RideToAdd.CarId);
            _uow.RidesRepository.Insert(ride);
            _uow.Save();
        }

        public RideInformationDTO GetRideInformation(int rideId)
        {
            var model = new RideInformationDTO();
            var ride = _context.Rides.Include(x => x.SourceLocation)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Car)
                .Include(x => x.Car.User)
                .Include(x => x.Car.User.Preferences)
                .Include(x => x.Passengers)
                .SingleOrDefault(x => x.Id == rideId);
            model.RideId = rideId;
            model.FirstName = ride.Car.User.FirstName;
            model.LastName = ride.Car.User.LastName;
            model.Phone = ride.Car.User.PhoneNumber;
            model.Email = ride.Car.User.Email;
            //model.Description = ride.Car.User.Preferences.Description;
            model.CarColor = ride.Car.Color;
            model.CarNumber = ride.Car.Number;
            model.CarModel = ride.Car.Model;
            model.SourceAddress = ride.SourceLocation.Street;
            model.SourceCity = ride.SourceLocation.City;
            model.SourceState = ride.SourceLocation.Country;
            model.DestinationAddress = ride.DestinationLocation.Street;
            model.DestinationCity = ride.DestinationLocation.City;
            model.DestinationState = ride.DestinationLocation.Country;
            model.Price = ride.Price;
            model.Passengers = ride.Passengers;
            return model;
        }
    }
}
