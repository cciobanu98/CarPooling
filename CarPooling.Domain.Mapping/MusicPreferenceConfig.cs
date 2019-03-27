using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class MusicPreferenceConfig : IEntityTypeConfiguration<MusicPreference>
    {
        public void Configure(EntityTypeBuilder<MusicPreference> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(255);
        }
    }
}
