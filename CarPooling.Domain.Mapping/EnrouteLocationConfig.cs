using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping 
{
    public class EnrouteLocationConfig : IEntityTypeConfiguration<EnrouteLocation>
    {
        public void Configure(EntityTypeBuilder<EnrouteLocation> builder)
        {
            builder.ToTable("EnrouteCity");
            builder.HasKey(ab => new { ab.LocationId, ab.RideId });
        }
    }
}
