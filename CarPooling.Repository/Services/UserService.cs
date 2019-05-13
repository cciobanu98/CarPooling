using System.Collections.Generic;
using System.Security.Claims;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Domain;
using CarPooling.DTO;
using Microsoft.AspNetCore.Identity;
using CarPooling.DataAcces.Interfaces;
using System.Linq;
using AutoMapper;
namespace CarPooling.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, IUnitOfWork uow, IMapper mapper)
        {
            _userManager = userManager;
            _uow = uow;
            _mapper = mapper;
        }

        public string GetUserIdByClaims(ClaimsPrincipal claims)
        {
            return _userManager.GetUserId(claims);
        }
        public List<CarInformationDTO> GetAllCarOfUser(ClaimsPrincipal claims)
        {
            var id = _userManager.GetUserId(claims);
            var Cars = _uow.CarsRepository.GetAll();
            var query = (from c in Cars
                        where c.UserId == id
                        select Mapper.Map<Car, CarInformationDTO>(c));
            return query.ToList();
        }

        public GeneralInformationDTO GetInformationAboutUser(ClaimsPrincipal claims)
        {
            var id = _userManager.GetUserId(claims);
            var user = _uow.UsersRepository.GetById(id);
            GeneralInformationDTO model = _mapper.Map<GeneralInformationDTO>(user);
            return model;
        }

        public void EditInformationAboutUser(ClaimsPrincipal claims, GeneralInformationDTO model)
        {
            var id = _userManager.GetUserId(claims);
            User user = _uow.UsersRepository.GetById(id);
            Mapper.Map<GeneralInformationDTO, User>(model, user);
            _uow.UsersRepository.Update(user);
            _uow.Save();
        }
    }
}
