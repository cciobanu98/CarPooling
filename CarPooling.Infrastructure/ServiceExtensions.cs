using CarPooling.BussinesLogic.Interfaces;
using CarPooling.BussinesLogic.Services;
using CarPooling.DataAcces.Interfaces;
using CarPooling.DataAcces.Repository;
using CarPooling.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace CarPooling.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));
            services.AddScoped(typeof(IRequestService), typeof(RequestService));
            services.AddScoped(typeof(IRideService), typeof(RideService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ICarService), typeof(CarService));
            services.AddScoped(typeof(IListGenerator), typeof(ListGenerator));
            services.AddScoped(typeof(ISelectRideService), typeof(SelectRideService));
            services.AddScoped(typeof(IRideHistoryService), typeof(RideHistoryService));
            services.AddScoped(typeof(IRatingService), typeof(RatingService));
            services.AddScoped(typeof(IPreferencesService), typeof(PreferencesService));
        }
    }
}
