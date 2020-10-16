namespace BCSystem.Application.BusinessCards.BusinessMans
{
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using Queries.Details;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IBusinessManQueryRepository : IQueryRepository<BusinessMan>
    {
        public Task<BusinessManDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken);
    }
}
