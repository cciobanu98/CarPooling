using System.Collections.Generic;
using System.Security.Claims;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.Domain;
using CarPooling.DTO;
using Microsoft.AspNetCore.Identity;
using CarPooling.DataAcces.Interfaces;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CarPooling.BussinesLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRatingService _ratingService;
        public UserService(UserManager<User> userManager, IUnitOfWork uow, IMapper mapper, IRatingService ratingService)
        {
            _userManager = userManager;
            _uow = uow;
            _mapper = mapper;
            _ratingService = ratingService;
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

        public ProfileDTO GetUserProfile(string userId)
        {
            var user = _uow.UsersRepository.GetFirstorDefault(
                include: s => s.Include(x => x.Preferences),
                predicate: x => x.Id == userId);
            var ratings = _ratingService.GetReceivedRatings(userId);
            var profile = _mapper.Map<User, ProfileDTO>(user);
            float general = 0;
            float accuracy = 0;
            float talkative = 0;
            if (ratings.Count != 0)
            {
                foreach (var r in ratings)
                {
                    general += r.General;
                    accuracy += r.Accuracy;
                    talkative += r.Talkative;
                }
                general = general / ratings.Count;
                accuracy = accuracy / ratings.Count;
                talkative = talkative / ratings.Count;
            }
            profile.GeneralRating = general;
            profile.AccuracyRating = accuracy;
            profile.TalkativeRating = talkative;
            return profile;
        }

        public string GetUserIdByUserName(string userName)
        {
            var user = _uow.UsersRepository.GetFirstorDefault(
                predicate: x => x.UserName == userName);
            return user.Id;
        }
    }
}
