using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class PreferencesConfig : IEntityTypeConfiguration<Preferences>
    {
        public void Configure(EntityTypeBuilder<Preferences> builder)
        {
        }
    }
}
