using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.DataAcces.Repository;
using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarPooling.Domain;
using System.Linq.Expressions;

namespace CarPooling.BussinesLogic.Services
{
    public class RideHistoryService : IRideHistoryService
    {
        private IMapper _mapper;
        private IUnitOfWork _uow;
        public RideHistoryService(IUnitOfWork uow ,IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        private Func<IQueryable<Ride>, IOrderedQueryable<Ride>> GetSortFuncEnroled(string sort)
        {
            switch (sort)
            {
                case "SortFromascending":
                    return s => s.OrderBy(x => x.SourceLocation.City);
                case "SortWhereascending":
                    return s => s.OrderBy(x => x.DestinationLocation.City);
                case "SortDateascending":
                    return s => s.OrderBy(x => x.TravelStartDateTime);
                case "SortPriceascending":
                    return s => s.OrderBy(x => x.Price);
                case "SortFromdescending":
                    return s => s.OrderByDescending(x => x.SourceLocation.City);
                case "SortWheredescending":
                    return s => s.OrderByDescending(x => x.DestinationLocation.City);
                case "SortDatedescending":
                    return s => s.OrderByDescending(x => x.TravelStartDateTime);
                case "SortPricedescending":
                    return s => s.OrderByDescending(x => x.Price);
                default:
                    return s => s.OrderBy(x => x.TravelStartDateTime);
            }
        }
       private Expression<Func<Ride, bool>> GetPredicateEnroled(string userId, string search)
        {
            Expression<Func<Ride, bool>> predicate;

            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = c => (c.SourceLocation.City.Contains(search) ||
                c.DestinationLocation.City.Contains(search)) &&
                c.Passengers.Any(y => y.UserId == userId);
            }
            else
            {
                predicate = x => x.Passengers.Any(y => y.UserId == userId);
            }
            return predicate;
        }
        public List<EnroledRideDTO> GetEnroledRide(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null)
        {
            var rides = _uow.RidesRepository.GetPage(
                predicate: GetPredicateEnroled(userId, search),
                orderBy: GetSortFuncEnroled(sort),
                include: s => s.Include(x => x.SourceLocation)
                .Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Passengers)
                .ThenInclude(y => y.User),
                pageIndex: pageIndex,
                pageSize: pageSize);
            return _mapper.Map<List<Ride>, List<EnroledRideDTO>>(rides); 
        }
        private Func<IQueryable<Ride>, IOrderedQueryable<Ride>> GetSortFuncOffered(string sort)
        {
            switch (sort)
            {
                case "SortFromascending":
                    return s => s.OrderBy(x => x.SourceLocation.City);
                case "SortWhereascending":
                    return s => s.OrderBy(x => x.DestinationLocation.City);
                case "SortDateascending":
                    return s => s.OrderBy(x => x.TravelStartDateTime);
                case "SortPriceascending":
                    return s => s.OrderBy(x => x.Price);
                case "SortFromdescending":
                    return s => s.OrderByDescending(x => x.SourceLocation.City);
                case "SortWheredescending":
                    return s => s.OrderByDescending(x => x.DestinationLocation.City);
                case "SortDatedescending":
                    return s => s.OrderByDescending(x => x.TravelStartDateTime);
                case "SortPricedescending":
                    return s => s.OrderByDescending(x => x.Price);
                default:
                    return s => s.OrderBy(x => x.TravelStartDateTime);
            }
        }
        private Expression<Func<Ride, bool>> GetPredicateOffered(string userId, string search)
        {
            Expression<Func<Ride, bool>> predicate;
            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = c => (c.SourceLocation.City.Contains(search) || 
                c.DestinationLocation.City.Contains(search) || 
                c.Car.User.UserName.Contains(search)) &&
                c.Car.User.Id == userId;
            }
            else
            {
                predicate = x => x.Car.User.Id == userId;
            }
            return predicate;
        }

        public List<OfferedRideDTO> GetOfferedRide(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null)
        {
            var rides = _uow.RidesRepository.GetPage(
                predicate: GetPredicateOffered(userId, search),
                orderBy: GetSortFuncOffered(sort),
                include: s => s.Include(x => x.SourceLocation)
                .Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Passengers)
                .ThenInclude(y => y.User),
                pageIndex:pageIndex,
                pageSize: pageSize);
            return _mapper.Map<List<Ride>, List<OfferedRideDTO>>(rides);
        }
        public int GetNumberOfOfferedRides(string userId, string search = null)
        {
            return _uow.RidesRepository.Count(
                 include: s => s.Include(x => x.SourceLocation)
                .Include(x => x.Car.User)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Passengers)
                .ThenInclude(y => y.User),
                predicate: GetPredicateOffered(userId, search));
        }
        public int GetNumberOfEnroledRides(string userId, string search = null)
        {
            return _uow.RidesRepository.Count(
                 include: s => s.Include(x => x.SourceLocation)
                .Include(x => x.DestinationLocation)
                .Include(x => x.Passengers)
                .ThenInclude(y => y.User),
                 predicate:GetPredicateEnroled(userId, search));
        }
    }
}
