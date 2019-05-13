using System;
using System.Collections.Generic;
using System.Text;
using CarPooling.Helpers;
using CarPooling.DTO;
using System.Linq;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface ISelectRideService
    {
        List<SelectedRidesWithDistanceDTO> GetSelectedRides(SelectRideDTO model, string sort = null, string search = null, int? pageIndex =null, int? pageSize = null);
        List<SelectedRidesDTO> GetAllRides(string sort =null, string search = null, int? pageIndex =null, int? pageSize = null);
        int GetNumberOfSelectedRides(SelectRideDTO model, string search);
        int GetNumberOfRides(string search);
    }
}
