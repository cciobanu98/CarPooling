using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class PassengerMapping : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasOne(x => x.Ride)
                .WithMany(x => x.Passengers)
                .HasForeignKey(x => x.RideId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
