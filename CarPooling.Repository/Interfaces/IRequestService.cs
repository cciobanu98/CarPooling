using CarPooling.DTO;
using CarPooling.Helpers;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IRequestService
    {
        string CreateRequest(int rideId, string userId);
        RequestDTO SetStatusOfRequest(int requestId, RequestStatus? status = null, bool IsRead = false);
    }
}
