using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class RideConfig : IEntityTypeConfiguration<Ride>
    {
        public void Configure(EntityTypeBuilder<Ride> builder)
        {
            builder.Property(x => x.CreatedDateTime)
                .IsRequired();
            //builder.Property(x => x.DestinationCity)
            //    .IsRequired();
            builder.Property(x => x.TravelStartDateTime)
                .IsRequired();
            //builder.Property(x => x.SourceCity)
            //    .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired();
           // builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.SourceCity)
            //    .WithOne(x => x.RideSorce)
            //    .HasForeignKey<Ride>(y => y.SourceCityId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(x => x.DestinationCity)
            //  .WithOne(x => x.RideDestination)
            //  .HasForeignKey<Ride>(y => y.DestinationCityId)
            //  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
