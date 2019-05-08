using CarPooling.BussinesLogic.Interfaces;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
using CarPooling.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace CarPooling.BussinesLogic.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CarService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public void AddCar(string userId, CarInformationDTO carDTO)
        {
            Car car = _mapper.Map<Car>(carDTO);
            car.UserId = userId;
            _uow.CarsRepository.Insert(car);
            _uow.Save();
        }
        public void DeleteCarById(int id)
        {
            _uow.CarsRepository.Delete(id);
            _uow.Save();
        }
        public void EditCar(CarInformationDTO carDTO)
        {
            Car car = _uow.CarsRepository.GetById(carDTO.Id);
            Mapper.Map(carDTO, car);
            _uow.CarsRepository.Update(car);
            _uow.Save();
        }
    }
}
