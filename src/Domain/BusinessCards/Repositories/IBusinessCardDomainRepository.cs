namespace BCSystem.Domain.BusinessCards.Repositories
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBusinessCardDomainRepository : IDomainRepository<BusinessCard>
    {
        Task<BusinessCard> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
