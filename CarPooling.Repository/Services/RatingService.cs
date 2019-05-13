using AutoMapper;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CarPooling.Context;

namespace CarPooling.BussinesLogic.Services
{
    public class RatingService : IRatingService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        private CarPoolingContext _context;
        public RatingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public void AddRatingToRide(RatingDTO rateDTO, string userId)
        {
            Rating rate= _mapper.Map<Rating>(rateDTO);
            rate.UserId = userId;
            _uow.RatingsRepository.Insert(rate);
            _uow.Save();
        }
        private Func<IQueryable<Rating>, IOrderedQueryable<Rating>> GetSortFuncLeft(string sort)
        {
            switch (sort)
            {
                case "SortTalkativeascending":
                    return s => s.OrderBy(x => x.Talkative);
                case "SortGeneralascending":
                    return s => s.OrderBy(x => x.General);
                case "SortAccuracyascending":
                    return s => s.OrderBy(x => x.Accuracy);
                case "SortNameascending":
                    return s => s.OrderBy(x => x.Ride.Car.User.UserName);
                case "SortTalkativedescending":
                    return s => s.OrderByDescending(x => x.Talkative);
                case "SortGeneraldescending":
                    return s => s.OrderByDescending(x => x.General);
                case "SortAccuracydescending":
                    return s => s.OrderByDescending(x => x.Accuracy);
                case "SortNamedescending":
                    return s => s.OrderByDescending(x => x.Ride.Car.User.UserName);
                default:
                    return s => s.OrderByDescending(x => x.Ride.Car.User.UserName);
            }
        }
        private Expression<Func<Rating, bool>> GetPredicateLeft(string userId, string search)
        {
            Expression<Func<Rating, bool>> predicate = c => (c.UserId == userId);

            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = c => c.User.UserName.Contains(search) &&
                                 (c.UserId == userId);
            }
            else
            {
                predicate = c => (c.UserId == userId);
            }
            return predicate;
        }
        public List<RatingLeftDTO> GetLeftRatings(string userId, string sort = null, string search = null, int? pageIndex= null, int? pageSize = null)
        {
           
            var ratings = _uow.RatingsRepository.GetPage(
                include: source => source.Include(x => x.Ride.Car.User),
                predicate: GetPredicateLeft(userId, search),
                orderBy: GetSortFuncLeft(sort),
                pageIndex: pageIndex,
                pageSize: pageSize);
            return _mapper.Map<List<Rating>, List<RatingLeftDTO>>(ratings);
        }
        private Expression<Func<Rating, bool>> GetPredicateReceived(string userId, string search)
        {
            Expression<Func<Rating, bool>> predicate = c => (c.Ride.Car.User.Id == userId);

            if (search != null && search != "" && search != "null" && search != "undefined")
            {
                predicate = c => c.Ride.Car.User.UserName.Contains(search) &&
                                 (c.Ride.Car.User.Id == userId);
            }
            else
            {
                predicate = c => (c.Ride.Car.User.Id == userId);
            }
            return predicate;
        }
        private Func<IQueryable<Rating>, IOrderedQueryable<Rating>> GetSortFuncReceived(string sort)
        {
            switch (sort)
            {
                case "SortTalkativeascending":
                    return s => s.OrderBy(x => x.Talkative);
                case "SortGeneralascending":
                    return s => s.OrderBy(x => x.General);
                case "SortAccuracyascending":
                    return s => s.OrderBy(x => x.Accuracy);
                case "SortNameascending":
                    return s => s.OrderBy(x => x.User.UserName);
                case "SortTalkativedescending":
                    return s => s.OrderByDescending(x => x.Talkative);
                case "SortGeneraldescending":
                    return s => s.OrderByDescending(x => x.General);
                case "SortAccuracydescending":
                    return s => s.OrderByDescending(x => x.Accuracy);
                case "SortNamedescending":
                    return s => s.OrderByDescending(x => x.User.UserName);
                default:
                    return s => s.OrderByDescending(x => x.User.UserName);
            }
        }
        public List<RatingReceivedDTO> GetReceivedRatings(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null)
        {
            var ratings = _uow.RatingsRepository.GetPage(
               include: source => source.Include(x => x.Ride.Car.User)
               .Include(x => x.User),
               predicate: GetPredicateReceived(userId, search),
               orderBy: GetSortFuncReceived(sort),
               pageIndex: pageIndex,
               pageSize: pageSize);
            return _mapper.Map<List<Rating>, List<RatingReceivedDTO>>(ratings);
        }
        public int GetNumberOfReceivedRatings(string userId, string search = null)
        {
            return _uow.RatingsRepository.Count(
                 include: source => source.Include(x => x.Ride.Car.User)
                 .Include(x => x.User),
                 predicate: GetPredicateReceived(userId, search));
        }
        public int GetNumberOfLeftRatings(string userId, string search = null)
        {
            return _uow.RatingsRepository.Count(
                include: source => source.Include(x => x.Ride.Car.User),
                predicate: GetPredicateLeft(userId, search));
        }

        public RatingDTO GetRaiting(int ratingId)
        {
            var rating = _uow.RatingsRepository.GetById(ratingId);
            return _mapper.Map<Rating, RatingDTO>(rating);
        }

        public void EditRating(RatingDTO model)
        {
            Rating rate = _uow.RatingsRepository.GetById(model.Id);
            Mapper.Map(model, rate);
            _uow.RatingsRepository.Update(rate);
            _uow.Save();
        }
        public void DeleteRatingById(int id)
        {
            _uow.RatingsRepository.Delete(id);
            _uow.Save();
        }
    }
}
