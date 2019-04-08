﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace CarPooling.Domain.Mapping
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(x => x.Username)
            //    .IsRequired()
            //    .HasMaxLength(32);
            //builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasMaxLength(32);
            builder.Property(x => x.LastName)
                .HasMaxLength(32);
            //builder.Property(x => x.Password)
            //    .IsRequired();
            //builder.Property(x => x.Phone)
            //    .HasMaxLength(32);
            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
