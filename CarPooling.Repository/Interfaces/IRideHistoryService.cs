using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IRideHistoryService
    {
        List<OfferedRideDTO> GetOfferedRide(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSeize = null);
        List<EnroledRideDTO> GetEnroledRide(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null);
        int GetNumberOfOfferedRides(string userId, string search = null);
        int GetNumberOfEnroledRides(string userId, string search = null);
    }
}
