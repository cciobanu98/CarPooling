using System;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
using System.Linq;
using CarPooling.DTO;
using CarPooling.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
namespace CarPooling.BussinesLogic.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public RequestService(IUnitOfWork uow, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public string CreateRequest(int rideId, string userId)
        {
            var ride = _uow.RidesRepository.GetFirstorDefault(
                predicate: x => x.Id == rideId,
                include: s => s.Include(x => x.Car.User)
                .Include(x => x.SourceLocation));
            var request = new Request
            {
                CreatedDateTime = DateTime.Now,
                RideId = rideId,
                Status = RequestStatus.Waiting,
                UserId = userId,
                IsRead = false
            };
            SelectRideDTO select = JsonConvert.DeserializeObject<SelectRideDTO>(_session.GetString("select"));
            var source = new Location
            {
                City = select.SourceCity,
                Country = select.SourceState,
                Street = select.SourceStreet,
                Latitude = select.SourceLocationLat,
                Longitude = select.SourceLocationLng
            };
            var destination = new Location
            {
                City = select.DestinationCity,
                Country = select.DestinationState,
                Street = select.DestinationStreet,
                Latitude = select.DestinationLocationLat,
                Longitude = select.DestinationLocationLng
            };
            request.Destination = destination;
            request.Source = source;
            _uow.RequestsRepository.Insert(request);
            _uow.Save();
            return ride.Car.User.Id;
        }

        public RequestDTO SetStatusOfRequest(int requestId, RequestStatus? status = null, bool IsRead = false)
        {
            var request = _uow.RequestsRepository.GetFirstorDefault(
                predicate: x => x.Id == requestId,
                include: s => s.Include(x => x.User));
            if (status != null)
            {
                request.Status = status ?? default;
            }
            request.IsRead = IsRead;
            _uow.RequestsRepository.Update(request);
            _uow.Save();
            RequestDTO toReturn = _mapper.Map<RequestDTO>(request);
            _mapper.Map<Request, RequestDTO>(request);
            return toReturn;
        }
    }
}
