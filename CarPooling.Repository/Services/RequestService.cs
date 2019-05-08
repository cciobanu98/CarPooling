using System;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
using System.Linq;
using CarPooling.DTO;
using CarPooling.Helpers;
using AutoMapper;

namespace CarPooling.BussinesLogic.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public RequestService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public string CreateRequest(int rideId, string userId)
        {
            var ride = _uow.RidesRepository.Get(filter: (x => x.Id == rideId), includeProperties: "Car.User,SourceLocation").FirstOrDefault();
            var request = new Request
            {
                CreatedDateTime = DateTime.Now,
                RideId = rideId,
                Status = RequestStatus.Waiting,
                UserId = userId,
                IsRead = false
            };
            _uow.RequestsRepository.Insert(request);
            _uow.Save();
            return ride.Car.User.Id;
        }

        public RequestDTO SetStatusOfRequest(int requestId, RequestStatus? status = null, bool IsRead = false)
        {
            var request = _uow.RequestsRepository.Get((x => x.Id == requestId), includeProperties:"User").SingleOrDefault();
            if (status != null)
            {
                request.Status = status ?? default;
            }
            request.IsRead = IsRead;
            _uow.RequestsRepository.Update(request);
            _uow.Save();
            RequestDTO toReturn = _mapper.Map<RequestDTO>(request);
            return toReturn;
        }
    }
}
