using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using CarPooling.Helpers;
using System.Collections.Generic;
using CarPooling.DataAcces.Interfaces;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CarPooling.Domain;
using System;
using System.Linq.Expressions;

namespace CarPooling.BussinesLogic.Services
{
    public class SelectRideService : ISelectRideService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public SelectRideService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        private Func<IQueryable<Ride>, IOrderedQueryable<Ride>> GetSortFuncSelected(string sort, SelectRideDTO select)
        {
            Coordinates destination = new Coordinates(select.DestinationLocationLat, select.DestinationLocationLng);
            Coordinates source = new Coordinates(select.SourceLocationLat, select.SourceLocationLng);
            switch (sort)
            {
                case "SortPriceascending":
                    return s => s.OrderBy(x => x.Price);
                case "SortSourceascending":
                    return s => s.OrderBy(x => Algo.GetDistanceInKm(source, new Coordinates(x.SourceLocation.Latitude, x.SourceLocation.Longitude)));
                case "SortDestinationascending":
                    return s => s.OrderBy(x => Algo.GetDistanceInKm(destination, new Coordinates(x.DestinationLocation.Latitude, x.DestinationLocation.Longitude)));
                case "SortDateascending":
                    return s => s.OrderBy(x => x.TravelStartDateTime);
                case "SortSeatsascending":
                    return s => s.OrderBy(x => x.Seats);
                case "SortPricedescending":
                    return s => s.OrderByDescending(x => x.Price);
                case "SortDatedescending":
                    return s => s.OrderByDescending(x => x.TravelStartDateTime);
                case "SortSeatsdescending":
                    return s => s.OrderByDescending(x => x.Seats);
                case "SortSourcedescending":
                    return s => s.OrderByDescending(x => Algo.GetDistanceInKm(source, new Coordinates(x.SourceLocation.Latitude, x.SourceLocation.Longitude)));
                case "SortDestinationdescending":
                    return s => s.OrderByDescending(x => Algo.GetDistanceInKm(destination, new Coordinates(x.DestinationLocation.Latitude, x.DestinationLocation.Longitude)));
                default:
                    return s => s.OrderByDescending(x => x.Price);
            }
        }
        private Expression<Func<Ride, bool>> GetPredicateSelected(SelectRideDTO model, string search)
        {
            Coordinates source = new Coordinates();
            Coordinates destination = new Coordinates();
            source.Lat = model.SourceLocationLat;
            source.Long = model.SourceLocationLng;
            destination.Lat = model.DestinationLocationLat;
            destination.Long = model.DestinationLocationLng;
            MinMaxLocation sourceRadius = Algo.GetMinMax(source);
            MinMaxLocation destinationRadius = Algo.GetMinMax(destination);

            Expression<Func<Ride, bool>> predicate;

            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = r => (r.Car.User.UserName.Contains(search) || r.DestinationLocation.City.Contains(search) || r.SourceLocation.City.Contains(search)) &&
                (r.SourceLocation.Latitude >= sourceRadius.minLat &&
                     r.SourceLocation.Latitude <= sourceRadius.maxLat &&
                     r.SourceLocation.Longitude >= sourceRadius.minLong &&
                     r.SourceLocation.Longitude <= sourceRadius.maxLong &&
                     r.DestinationLocation.Latitude >= destinationRadius.minLat &&
                     r.DestinationLocation.Latitude <= destinationRadius.maxLat &&
                     r.DestinationLocation.Longitude >= destinationRadius.minLong &&
                     r.DestinationLocation.Longitude <= destinationRadius.maxLong &&
                     r.TravelStartDateTime >= Convert.ToDateTime(model.TravelStartDateTime) &&
                     r.Seats > 0 );
            }
            else
            {
                predicate = r => (r.SourceLocation.Latitude >= sourceRadius.minLat &&
                       r.SourceLocation.Latitude <= sourceRadius.maxLat &&
                       r.SourceLocation.Longitude >= sourceRadius.minLong &&
                       r.SourceLocation.Longitude <= sourceRadius.maxLong &&
                       r.DestinationLocation.Latitude >= destinationRadius.minLat &&
                       r.DestinationLocation.Latitude <= destinationRadius.maxLat &&
                       r.DestinationLocation.Longitude >= destinationRadius.minLong &&
                       r.DestinationLocation.Longitude <= destinationRadius.maxLong &&
                       r.TravelStartDateTime >= Convert.ToDateTime(model.TravelStartDateTime) &&
                       r.Seats > 0);
            }
            return predicate;
        }
        public List<SelectedRidesWithDistanceDTO> GetSelectedRides(SelectRideDTO model, string sort = null, string search = null ,int? pageIndex = null, int? pageSize = null)
        {
            
            var rides = _uow.RidesRepository.GetPage(
                include: s => s.Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.SourceLocation),
                predicate:GetPredicateSelected(model, search),
                orderBy: GetSortFuncSelected(sort, model),
                pageIndex:pageIndex,
                pageSize: pageSize);
            return _mapper.Map<List<Ride>, List<SelectedRidesWithDistanceDTO>>(rides, opt => opt.Items["SelectRide"] = model);
        }
        public int GetNumberOfSelectedRides(SelectRideDTO model, string search)
        {
            return _uow.RidesRepository.Count(
                 include: s => s.Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.SourceLocation),
                predicate: GetPredicateSelected(model, search));
        }
        public int GetNumberOfRides(string search)
        {
            return _uow.RidesRepository.Count(
                include: s => s.Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.SourceLocation),
                predicate: GetPredicateAllSelected(search));
        }
        private Func<IQueryable<Ride>, IOrderedQueryable<Ride>> GetSortFuncAllSelected(string sort)
        {
            switch (sort)
            {
                case "SortPriceascending":
                    return s => s.OrderBy(x => x.Price);
                case "SortDateascending":
                    return s => s.OrderBy(x => x.TravelStartDateTime);
                case "SortSeatsascending":
                    return s => s.OrderBy(x => x.Seats);
                case "SortPricedescending":
                    return s => s.OrderByDescending(x => x.Price);
                case "SortDatedescending":
                    return s => s.OrderByDescending(x => x.TravelStartDateTime);
                case "SortSeatsdescending":
                    return s => s.OrderByDescending(x => x.Seats);
                default:
                    return s => s.OrderByDescending(x => x.Price);
            }
        }
        private Expression<Func<Ride, bool>> GetPredicateAllSelected(string search)
        {
            Expression<Func<Ride, bool>> predicate;

            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = x => (x.Car.User.UserName.Contains(search) || x.DestinationLocation.City.Contains(search) || x.SourceLocation.City.Contains(search));
            }
            else
            {
                predicate = x => true;
            }
            return predicate;
        }
        public List<SelectedRidesDTO> GetAllRides(string sort = null, string search = null, int? pageIndex = null, int? pageSize = null)
        {
            var rides = _uow.RidesRepository.GetPage(
                predicate: GetPredicateAllSelected(search),
                orderBy: GetSortFuncAllSelected(sort),
                include: s => s.Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.SourceLocation),
                pageIndex: pageIndex,
                pageSize: pageSize);
            return _mapper.Map<List<Ride>, List<SelectedRidesDTO>>(rides);
        }
       
    }
}
