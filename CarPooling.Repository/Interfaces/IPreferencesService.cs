using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface IPreferencesService
    {
        void Edit(PreferencesDTO dto, string userId);
        PreferencesDTO GetPreferences(string userId);
    }
}
