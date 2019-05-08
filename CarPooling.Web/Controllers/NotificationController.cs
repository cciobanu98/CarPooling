using Microsoft.AspNetCore.Mvc;
using CarPooling.BussinesLogic.Interfaces;

namespace CarPooling.Web.Controllers
{
    public class NotificationController : Controller
    {
        public readonly IRequestService _requestService;
        public readonly INotificationService _notificationService;
        public readonly IUserService _userService;
        public NotificationController(
            IRequestService requestService,
            INotificationService notificationService,
            IUserService userService)
        {
            _requestService = requestService;
            _notificationService = notificationService;
            _userService = userService;
        }
        public IActionResult GetNotification()
        {
            var userId = _userService.GetUserIdByClaims(HttpContext.User);
            var notification = _notificationService.GetNotificationsOfUser(userId);
            return Ok(notification);
        }
        [HttpPost]
        public IActionResult ReadNotification(int requestId)
        {
             _requestService.SetStatusOfRequest(requestId, IsRead: true);
            string userId = _userService.GetUserIdByClaims(HttpContext.User);
            _notificationService.SendNotificationToUser(userId);
            return Ok();
        }
    }
}
