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
        public CarPoolingContext() : base()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
        public DbSet<ChatPreferences> ChatPreferences { get; set; }
        public DbSet<MusicPreferences> MusicPreferences { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<GeneralPreferences> GeneralPreferences {get; set;}
        public DbSet<EnrouteLocation> EnrouteLocations{ get; set; }
        public CarPoolingContext(DbContextOptions<CarPoolingContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new CarMapping());
            modelBuilder.ApplyConfiguration(new PreferencesMapping());
            modelBuilder.ApplyConfiguration(new LocationMapping());
            modelBuilder.ApplyConfiguration(new PreferencesMapping());
            modelBuilder.ApplyConfiguration(new RequestMapping());
            modelBuilder.ApplyConfiguration(new RideMapping());
            modelBuilder.ApplyConfiguration(new EnrouteLocationMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = CarPoolingAppSettings.ConfigurationRoot.GetConnectionString("CarPoolingConnection");
            var connectionString = "Data Source=.;Initial Catalog=CarPoolingEF;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
