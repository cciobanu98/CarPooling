using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class ChatPreferenceConfig : IEntityTypeConfiguration<ChatPreference>
    {
        public void Configure(EntityTypeBuilder<ChatPreference> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(255);
        }
    }
}
