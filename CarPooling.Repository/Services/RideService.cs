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
using CarPooling.Helpers;
using AutoMapper;

namespace CarPooling.BussinesLogic.Services
{
    public class RideService : IRideService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public RideService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public void AddPassengerToRide(int rideId, string passengerId, int requestId)
        {
            var Ride = _uow.RidesRepository.GetFirstorDefault(
                predicate: x => x.Id == rideId,
                include: s => s.Include(x => x.Passengers));
            if (Ride.Seats == 0)
                throw new Exception("Seats cannot be negative");
            Passenger passenger = new Passenger();
            passenger.UserId = passengerId;
            passenger.RideId = rideId;
            passenger.RequestId = requestId;
            Ride.Passengers.Add(passenger);
            Ride.Seats--;
            //Add Error of Seats
            _uow.RidesRepository.Update(Ride);
            _uow.Save();
        }

        public void AddRide(RideDTO RideToAdd)
        {
            Ride ride = _mapper.Map<RideDTO, Ride>(RideToAdd);
            ride.CreatedDateTime = DateTime.Now;
            _uow.RidesRepository.Insert(ride);
            _uow.Save();
        }
        public RideInformationDTO GetRideInformation(int rideId)
        {
            var ride = _uow.RidesRepository.GetFirstorDefault(
                predicate: x => x.Id == rideId,
                include: s => s.Include(x => x.SourceLocation)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Car)
                .Include(x => x.Car.User)
                .Include(x => x.Car.User.Preferences)
                .Include(x => x.Passengers)
                .ThenInclude(x => x.Request.Source)
                .Include(x => x.Passengers)
                .ThenInclude(x => x.Request.Destination)
                .Include(x => x.Passengers)
                .ThenInclude(x => x.Request.User)
                .Include(x => x.Passengers)
                .ThenInclude(x => x.User));
            return _mapper.Map<Ride, RideInformationDTO>(ride);
        }

        public void AddInformationAboutSelect(RideInformationDTO rideInformation, SelectRideDTO select)
        {
            rideInformation.DistanceFromSource = Algo.GetDistanceInKm(new Coordinates(rideInformation.SourceLat, rideInformation.SourgeLng),
                new Coordinates(select.SourceLocationLat, select.SourceLocationLng));
            rideInformation.DistanceFromDestination = Algo.GetDistanceInKm(new Coordinates(rideInformation.DestinationLat, rideInformation.DestinationLng),
                new Coordinates(select.DestinationLocationLat, select.DestinationLocationLng));
        }
    }
}
