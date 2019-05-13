using AutoMapper;
using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace CarPooling.BussinesLogic.Services
{
    public class PreferencesService : IPreferencesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserService _userService;
        public PreferencesService(IMapper mapper, IUnitOfWork uow, IUserService userService)
        {
            _mapper = mapper;
            _uow = uow;
            _userService = userService;
        }
        public void Edit(PreferencesDTO dto, string userId)
        {
            var preferences = _mapper.Map<PreferencesDTO, Preferences>(dto);
            preferences.UserId = userId;
            var user = _uow.UsersRepository.GetFirstorDefault(
                predicate: x => x.Id == userId,
                include: s => s.Include(x => x.Preferences));
            if (user.Preferences == null)
                _uow.PreferencesRepository.Insert(preferences);
            else
                _uow.PreferencesRepository.Update(preferences);
            _uow.Save();
        }

        public PreferencesDTO GetPreferences(string userId)
        {
            var dto = _uow.PreferencesRepository.GetFirstorDefault(
                predicate: x => x.UserId == userId);
            return _mapper.Map<Preferences, PreferencesDTO>(dto);
        }
    }
}
