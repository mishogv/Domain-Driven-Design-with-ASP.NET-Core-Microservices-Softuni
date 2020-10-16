namespace BCSystem.Application.BusinessCards.BusinessCards
{
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    public interface IBusinessCardQueryRepository : IQueryRepository<BusinessCard>
    {
    }
}
