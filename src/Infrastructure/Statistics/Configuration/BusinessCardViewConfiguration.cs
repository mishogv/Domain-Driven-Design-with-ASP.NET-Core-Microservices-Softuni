namespace BCSystem.Infrastructure.Statistics.Configuration
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using Domain.Statistics.Models;
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BusinessCardViewConfiguration : IEntityTypeConfiguration<BusinessCardView>
    {
        public void Configure(EntityTypeBuilder<BusinessCardView> builder)
        {
            builder
                .HasKey(cav => cav.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<BusinessCard>()
                .WithMany()
                .HasForeignKey(c => c.BusinessCardId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
