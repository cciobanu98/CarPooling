using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class RideMapping : IEntityTypeConfiguration<Ride>
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
            //builder.HasOne(x => x.SourceLocation)
            //    .WithOne(x => x.)
            //    .OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(x => x.DestinationLocation)
            //  .WithOne(x => x.Destination)
            //  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
