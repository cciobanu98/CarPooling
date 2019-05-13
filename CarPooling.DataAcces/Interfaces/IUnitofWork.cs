using CarPooling.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPooling.DataAcces.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<User> UsersRepository { get; }
        GenericRepository<Car> CarsRepository { get; }
        GenericRepository<Ride> RidesRepository { get; }
        GenericRepository<Request> RequestsRepository { get; }
        GenericRepository<Rating> RatingsRepository { get; }
        GenericRepository<Preferences> PreferencesRepository { get; }
        void Save();
    }
}
