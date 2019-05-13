using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace CarPooling.Domain.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName)
                .HasMaxLength(32);
            builder.Property(x => x.LastName)
                .HasMaxLength(32);
            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
