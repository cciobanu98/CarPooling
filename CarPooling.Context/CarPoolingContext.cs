using CarPooling.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarPooling.Domain.Mapping;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace CarPooling.Context
{
    public class CarPoolingContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<ChatPreferences> ChatPreferences { get; set; }
        public DbSet<MusicPreferences> MusicPreferences { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<MemberCar> MemberCars { get; set; }
        public DbSet<GeneralPreferences> GeneralPreferences {get; set;}
        public DbSet<EnrouteCity> EnrouteCities { get; set; }
        public CarPoolingContext(DbContextOptions<CarPoolingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new CarConfig());
            modelBuilder.ApplyConfiguration(new PreferencesConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new MemberCarConfig());
            modelBuilder.ApplyConfiguration(new PreferencesConfig());
            modelBuilder.ApplyConfiguration(new RequestConfig());
            modelBuilder.ApplyConfiguration(new RideConfig());
            modelBuilder.ApplyConfiguration(new EnrouteCityConfig());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //var connectionString = CarPoolingAppSettings.ConfigurationRoot.GetConnectionString("CarPoolingConnection");
        //    var connectionString = "Data Source=.;Initial Catalog=CarPoolingEF;Integrated Security=True;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
