namespace BCSystem.Infrastructure.BusinessCards.Configuration
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using static Domain.BusinessCards.Models.ModelConstants.Common;
    using static Domain.BusinessCards.Models.ModelConstants.BusinessCard;

    public class BusinessCardConfiguration : IEntityTypeConfiguration<BusinessCard>
    {
        public void Configure(EntityTypeBuilder<BusinessCard> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(MaxDescriptionLength);

            builder
                .Property(x => x.Address)
                .IsRequired();

            builder
                .Property(x => x.LogoUrl)
                .IsRequired();

            builder
                .Property(x => x.SiteUrl)
                .IsRequired();
        }
    }
}
