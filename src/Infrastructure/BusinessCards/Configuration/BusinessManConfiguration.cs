namespace BCSystem.Infrastructure.BusinessCards.Configuration
{
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using BCSystem.Infrastructure.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static BCSystem.Domain.BusinessCards.Models.ModelConstants.Common;

    public class BusinessManConfiguration : IEntityTypeConfiguration<BusinessMan>
    {
        public void Configure(EntityTypeBuilder<BusinessMan> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<BusinessMan>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(
                x => x.PhoneNumber,
                y =>
                {
                    y.WithOwner();
                    y.Property(pn => pn.Number);
                });

            builder
                .HasMany(x => x.BusinessCards)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("businessCards");
        }
    }
}
