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
        }
    }
}
