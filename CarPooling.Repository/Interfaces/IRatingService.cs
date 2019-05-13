using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IRatingService
    {
        void AddRatingToRide(RatingDTO rate, string userId);
        List<RatingLeftDTO> GetLeftRatings(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null);
        List<RatingReceivedDTO>  GetReceivedRatings(string userId, string sort = null, string search = null, int? pageIndex = null, int? pageSize = null);
        int GetNumberOfReceivedRatings(string userId, string search = null);
        int GetNumberOfLeftRatings(string userId, string search = null);
    }
}
