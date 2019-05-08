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
        List<SelectedRidesDTO> GetSelectedRides(SelectRideDTO model);
        List<SelectedRidesDTO> GetAllRides();
        List <SelectedRidesDTO> PaginateRides(IQueryable<SelectedRidesDTO> query, int skip, int size);
        IQueryable<SelectedRidesDTO> SortAndFilterRides(IQueryable<SelectedRidesDTO> query, string search, string sort);
    }
}
