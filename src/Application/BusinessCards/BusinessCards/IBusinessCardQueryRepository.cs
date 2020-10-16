namespace BCSystem.Application.BusinessCards.BusinessCards
{
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBusinessCardQueryRepository : IQueryRepository<BusinessCard>
    {
        public Task<BusinessCardOutputModel> GetDetails(int id, CancellationToken cancellationToken);
    }
}
