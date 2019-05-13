using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class PreferencesMapping : IEntityTypeConfiguration<Preferences>
    {
        public void Configure(EntityTypeBuilder<Preferences> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(255);
            builder.HasKey(x => x.UserId);
            builder.HasOne(x => x.User)
                .WithOne(x => x.Preferences)
                .HasForeignKey<Preferences>(y => y.UserId);
            builder.Property(x => x.RowVersion)
               .IsRowVersion();
        }
    }
}
