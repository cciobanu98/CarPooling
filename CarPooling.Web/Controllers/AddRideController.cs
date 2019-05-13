using Microsoft.AspNetCore.Mvc;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DTO;
using CarPooling.Helpers;
using System.Collections.Generic;

namespace CarPooling.Web.Controllers
{
    public class AddRideController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IRequestService _requestService;
        private readonly IRideService _rideService;
        private readonly IUserService _userService;
        public AddRideController(
            INotificationService notificationService,
            IRequestService requestService,
            IRideService rideService,
            IUserService userService)
        {
            _notificationService = notificationService;
            _requestService = requestService;
            _rideService = rideService;
            _userService = userService;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            //Try to Change to Model
            List<CarInformationDTO> cars = _userService.GetAllCarOfUser(HttpContext.User);
            ViewData["List"] = cars;
            return View();
        }

        [HttpPost]
        public IActionResult Index(RideDTO rideModel)
        {
            if (ModelState.IsValid)
            {
                _rideService.AddRide(rideModel);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "RideInformationError");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult SubscribeToRide(int rideId)
        {
            string fromUserId = _userService.GetUserIdByClaims(HttpContext.User);
            string toUserId = _requestService.CreateRequest(rideId, fromUserId);
            _notificationService.SendNotificationToUser(toUserId);          
            return Ok();
        }
        [HttpPost]
        public IActionResult AcceptPassengers(int requestId)
        {
            RequestDTO request = _requestService.SetStatusOfRequest(requestId, RequestStatus.Accepted);
            _rideService.AddPassengerToRide(request.RideId, request.Requester, requestId);
            _notificationService.SendNotificationToUser(request.Requester);
            string userId = _userService.GetUserIdByClaims(HttpContext.User);
            _notificationService.SendNotificationToUser(userId);
            return Ok();
        }
        [HttpPost]
        public IActionResult RejectPassengers(int requestId)
        {
            RequestDTO request = _requestService.SetStatusOfRequest(requestId, RequestStatus.Rejected);
            _notificationService.SendNotificationToUser(request.Requester);
            string userId = _userService.GetUserIdByClaims(HttpContext.User);
            _notificationService.SendNotificationToUser(userId);
            return Ok();
        }
    }
}
