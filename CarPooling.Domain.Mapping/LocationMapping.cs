using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class LocationMapping : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
