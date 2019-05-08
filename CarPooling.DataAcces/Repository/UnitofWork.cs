using System;
using System.Collections.Generic;
using System.Text;
using CarPooling.Context;
using CarPooling.DataAcces.Interfaces;
using CarPooling.Domain;
namespace CarPooling.DataAcces.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private CarPoolingContext context = new CarPoolingContext();
        private GenericRepository<User> usersRepository;
        private GenericRepository<Car> carsRepository;
        private GenericRepository<Ride> ridesRepository;
        private GenericRepository<Request> requestsRepository;

        public GenericRepository<User> UsersRepository
        {
            get
            {

                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<User>(context);
                }
                return usersRepository;
            }
        }

        public GenericRepository<Car> CarsRepository
        {
            get
            {

                if (this.carsRepository == null)
                {
                    this.carsRepository = new GenericRepository<Car>(context);
                }
                return carsRepository;
            }
        }
        public GenericRepository<Ride> RidesRepository
        {
            get
            {

                if (this.ridesRepository == null)
                {
                    this.ridesRepository = new GenericRepository<Ride>(context);
                }
                return ridesRepository;
            }
        }
        public GenericRepository<Request> RequestsRepository
        {
            get
            {

                if (this.requestsRepository == null)
                {
                    this.requestsRepository = new GenericRepository<Request>(context);
                }
                return requestsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
