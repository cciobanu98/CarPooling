using CarPooling.DTO;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IRideService
    {
        void AddPassengerToRide(int rideId, string passengerId, int requestId);
        void AddRide(RideDTO RideToAdd);
        RideInformationDTO GetRideInformation(int rideId);
        void AddInformationAboutSelect(RideInformationDTO rideInformation, SelectRideDTO select);
    }
}
