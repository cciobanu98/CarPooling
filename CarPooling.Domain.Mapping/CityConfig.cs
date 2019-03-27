using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.CityName)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
