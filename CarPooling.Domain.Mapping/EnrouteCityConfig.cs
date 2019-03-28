using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping 
{
    public class EnrouteCityConfig : IEntityTypeConfiguration<EnrouteCity>
    {
        public void Configure(EntityTypeBuilder<EnrouteCity> builder)
        {
            builder.ToTable("EnrouteCity");
            builder.HasKey(ab => new { ab.CityId, ab.RideId });
        }
    }
}
