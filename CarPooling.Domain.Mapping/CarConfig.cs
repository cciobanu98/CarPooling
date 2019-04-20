using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(x => x.Color)
                 .HasMaxLength(32);
            builder.Property(x => x.Model)
                .HasMaxLength(32);
            builder.Property(x => x.Number)
                .HasMaxLength(32);
        }
    }
}
