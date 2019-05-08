using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Context;
using CarPooling.DTO;
using CarPooling.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarPooling.BussinesLogic.Services
{
    public class SelectRideService : ISelectRideService
    {
        private readonly CarPoolingContext _context;
        public SelectRideService(CarPoolingContext context)
        {
            _context = context;
        }
        private MinMaxLocation GetMinMax(Coordinates c)
        {
            MinMaxLocation temp = new MinMaxLocation();
            temp.minLat = c.Lat - 1;
            temp.maxLat = c.Lat + 1;
            temp.minLong = c.Long - 1;
            temp.maxLong = c.Long + 1;
            return temp;
        }
        private double deg2rad(float deg)
        {
            return deg * (Math.PI / 180);
        }
        private float GetDistanceInKm(Coordinates c1, Coordinates c2)
        {
            int R = 6371; // Radius of earth in km
            Coordinates dc = new Coordinates();
            dc.Lat = (float)deg2rad(c1.Lat - c2.Lat);
            dc.Long = (float)deg2rad(c1.Long - c2.Long);
            var a = Math.Sin(dc.Lat / 2) * Math.Sin(dc.Lat / 2) +
                    Math.Cos(deg2rad(c1.Lat)) * Math.Cos(deg2rad(c2.Lat)) *
                    Math.Sin(dc.Long / 2) * Math.Sin(dc.Long / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return (float)d;
        }
        private IQueryable<SelectedRidesDTO> Sort(IQueryable<SelectedRidesDTO> query, string sort)
        {
            switch (sort)
            {
                case "SortPriceascending":
                    return query.OrderBy(x => x.Price);
                case "SortSourceascending":
                    return query.OrderBy(x => x.DistanceFromSource);
                case "SortDestinationascending":
                    return query.OrderBy(x => x.DistanceFromDestination);
                case "SortDateascending":
                    return query.OrderBy(x => x.TravelStartDateTime);
                case "SortSeatsascending":
                    return query.OrderBy(x => x.Seats);
                case "SortPricedescending":
                    return query.OrderByDescending(x => x.Price);
                case "SortSourcedescending":
                    return query.OrderByDescending(x => x.DistanceFromSource);
                case "SortDestinationdescending":
                    return query.OrderByDescending(x => x.DistanceFromDestination);
                case "SortDatedescending":
                    return query.OrderByDescending(x => x.TravelStartDateTime);
                case "SortSeatsdescending":
                    return query.OrderByDescending(x => x.Seats);
                default:
                    return query.OrderByDescending(x => x.Price);
            }
        }
        public List<SelectedRidesDTO> GetSelectedRides(SelectRideDTO model)
        {
            Coordinates source = new Coordinates();
            Coordinates destination = new Coordinates();
            source.Lat = model.SourceLocationLat;
            source.Long = model.SourceLocationLng;
            destination.Lat = model.DestinationLocationLat;
            destination.Long = model.DestinationLocationLng;
            MinMaxLocation sourceRadius = GetMinMax(source);
            MinMaxLocation destinationRadius = GetMinMax(destination);
            var query = (from r in _context.Rides.Include(x => x.Car.User)
                       .Include(x => x.DestinationLocation)
                       .Include(x => x.SourceLocation)
                         where (r.SourceLocation.Latitude >= sourceRadius.minLat &&
                         r.SourceLocation.Latitude <= sourceRadius.maxLat &&
                         r.SourceLocation.Longitude >= sourceRadius.minLong &&
                         r.SourceLocation.Longitude <= sourceRadius.maxLong &&
                         r.DestinationLocation.Latitude >= destinationRadius.minLat &&
                         r.DestinationLocation.Latitude <= destinationRadius.maxLat &&
                         r.DestinationLocation.Longitude >= destinationRadius.minLong &&
                         r.DestinationLocation.Longitude <= destinationRadius.maxLong &&
                         r.TravelStartDateTime >= Convert.ToDateTime(model.TravelStartDateTime))
                         select new SelectedRidesDTO
                         {
                             Source = r.SourceLocation.City,
                             Destination = r.DestinationLocation.City,
                             Seats = r.Seats,
                             Price = r.Price,
                             Username = r.Car.User.UserName,
                             DistanceFromSource = GetDistanceInKm(source, new Coordinates(r.SourceLocation.Latitude, r.SourceLocation.Longitude)),
                             DistanceFromDestination = GetDistanceInKm(destination, new Coordinates(r.DestinationLocation.Latitude, r.DestinationLocation.Longitude)),
                             TravelStartDateTime = r.TravelStartDateTime,
                             Id = r.Id,
                             CreatedDateTime = r.CreatedDateTime
                         });
            return query.ToList();
        }
        public List<SelectedRidesDTO> GetAllRides()
        {
            var query = (from r in _context.Rides.Include(x => x.Car.User)
            .Include(x => x.DestinationLocation)
            .Include(x => x.SourceLocation)
                         select new SelectedRidesDTO
                         {
                             Id = r.Id,
                             Destination = r.DestinationLocation.City,
                             Source = r.SourceLocation.City,
                             Seats = r.Seats,
                             TravelStartDateTime = r.TravelStartDateTime,
                             Username = r.Car.User.UserName,
                             Price = r.Price,
                             CreatedDateTime = r.CreatedDateTime,
                         });
            return query.ToList();
        }
        public IQueryable<SelectedRidesDTO> SortAndFilterRides(IQueryable<SelectedRidesDTO> query, string search, string sort)
        {
            query = Sort(query, sort);
            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                query = query.Where(x => x.Username.Contains(search) || x.Destination.Contains(search) || x.Source.Contains(search));
            }
            return query;
        }
        public List<SelectedRidesDTO> PaginateRides(IQueryable<SelectedRidesDTO> query, int skip, int size)
        {
            query = query.Skip(skip).Take(size);
            return query.ToList();
        }
    }
}
