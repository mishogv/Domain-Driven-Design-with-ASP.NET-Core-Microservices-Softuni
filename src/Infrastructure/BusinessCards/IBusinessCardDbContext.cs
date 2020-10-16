namespace BCSystem.Infrastructure.BusinessCards
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using BCSystem.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface IBusinessCardDbContext : IDbContext
    {
        DbSet<BusinessCard> BusinessCards { get; }

        DbSet<BusinessMan> BusinessMens { get; }
    }
}
