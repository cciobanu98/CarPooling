using CarPooling.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CarPooling.Domain.Mapping;
namespace CarPooling.Context
{
    public class CarPoolingContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<ChatPreference> ChatPreferences { get; set; }
        public DbSet<MusicPreference> MusicPreferences { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<MemberCar> MemberCars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(UserConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(CarConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(ChatPreferenceConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(CityConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(MemberCarConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(MusicPreferenceConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(PreferencesConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(RequestConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            assembly = typeof(RideConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = CarPoolingAppSettings.ConfigurationRoot.GetConnectionString("CarPoolingConnection");
            var connectionString = "Data Source=.;Initial Catalog=CarPoolingEF;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
