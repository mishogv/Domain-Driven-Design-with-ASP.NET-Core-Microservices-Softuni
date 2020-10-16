namespace BCSystem.Domain.BusinessCards.Repositories
{
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using BCSystem.Domain.Common;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBusinessManDomainRepository : IDomainRepository<BusinessMan>
    {
        Task<BusinessMan> Find(string id, CancellationToken cancellationToken = default);

        Task<int> GetBusinessManId(string userId, CancellationToken cancellationToken = default);
    }
}
