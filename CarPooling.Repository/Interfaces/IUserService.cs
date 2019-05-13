using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using CarPooling.DTO;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IUserService
    {
        string GetUserIdByClaims(ClaimsPrincipal claims);
        List<CarInformationDTO> GetAllCarOfUser(ClaimsPrincipal claims);
        GeneralInformationDTO GetInformationAboutUser(ClaimsPrincipal claims);
        void EditInformationAboutUser(ClaimsPrincipal claims, GeneralInformationDTO model);
    }
}
