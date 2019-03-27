using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPooling.Domain.Mapping
{
    public class MemberCarConfig : IEntityTypeConfiguration<MemberCar>
    {
        public void Configure(EntityTypeBuilder<MemberCar> builder)
        {
            builder.ToTable("MembersCars");
            builder.HasKey(ab => new { ab.CarId, ab.UserId });
           
        }
    }
}
