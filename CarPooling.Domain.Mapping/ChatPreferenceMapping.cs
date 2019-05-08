using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class ChatPreferenceMapping : IEntityTypeConfiguration<ChatPreferences>
    {
        public void Configure(EntityTypeBuilder<ChatPreferences> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(255);
        }
    }
}
