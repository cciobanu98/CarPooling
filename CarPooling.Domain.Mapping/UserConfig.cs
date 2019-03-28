using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace CarPooling.Domain.Mapping
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Password)
                .IsRequired();
            builder.Property(x => x.Phone)
                .HasMaxLength(32);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
