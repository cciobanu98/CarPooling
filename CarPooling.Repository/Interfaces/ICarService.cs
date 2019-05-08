using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.BussinesLogic.Interfaces
{
    public interface ICarService
    {
        void AddCar(string userId, CarInformationDTO carDTO);
        void DeleteCarById(int Id);
        void EditCar(CarInformationDTO carDTO);
    }
}
