using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.Property(x => x.CreatedDateTime)
                .IsRequired();
            builder.HasOne(x => x.Source)
                .WithOne(x => x.RequestSource)
                .HasForeignKey<Request>(x => x.SourceId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Destination)
                .WithOne(x => x.RequestDestination)
                .HasForeignKey<Request>(x => x.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
