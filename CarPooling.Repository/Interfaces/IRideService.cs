using CarPooling.DTO;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IRideService
    {
        void AddPassengerToRide(int rideId, string passengerId);
        void AddRide(RideDTO RideToAdd);
        RideInformationDTO GetRideInformation(int rideId);
    }
}
