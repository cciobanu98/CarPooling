using CarPooling.DTO;
namespace CarPooling.BussinesLogic.Interfaces
{
    public interface INotificationService
    {
        void SendNotificationToUser(string userId);
        NotificationDTO GetNotificationsOfUser(string userId);
    }
}
