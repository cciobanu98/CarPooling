using CarPooling.BussinesLogic.Interfaces;
using Microsoft.AspNetCore.SignalR;
using CarPooling.BussinesLogic.Hubs;
using CarPooling.DTO;
using CarPooling.Helpers;
using System.Collections.Generic;
using CarPooling.Domain;
using CarPooling.DataAcces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarPooling.BussinesLogic.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IUnitOfWork _uow;
        public NotificationService(IHubContext<NotificationHub> hubContext, IUnitOfWork uow)
        {
            _hubContext = hubContext;
            _uow = uow;
        }

        public NotificationDTO GetNotificationsOfUser(string userId)
        {
           var notifications = _uow.RequestsRepository.Get(
                include: source => source.Include(x => x.User)
                .Include(x => x.Ride.SourceLocation)
                .Include(x => x.Ride.DestinationLocation)
                .Include(x => x.Ride.Car.User)
                .Include(x => x.Source)
                .Include(x => x.Destination),
                predicate: x => x.IsRead == false);
            var list = new List<Request>();
            foreach (var n in notifications)
            {
                if (n.Status == RequestStatus.Waiting && n.Ride.Car.User.Id == userId)
                    list.Add(n);
                else if ((n.Status == RequestStatus.Accepted || n.Status == RequestStatus.Rejected) && n.User.Id == userId)
                    list.Add(n);
            }
            return new NotificationDTO { Requests = list, Count = list.Count };
        }

        public void SendNotificationToUser(string userId)
        { 
            _hubContext.Clients.User(userId).SendAsync("displayNotification", "");
        }

    }
}
