namespace BCSystem.Infrastructure.BusinessCards.Repositories
{
    using BCSystem.Application.BusinessCards.BusinessCards;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.BusinessCards.Repositories;
    using BCSystem.Infrastructure.Common.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BusinessCardRepository : DataRepository<IBusinessCardDbContext, BusinessCard>,              IBusinessCardQueryRepository,
        IBusinessCardDomainRepository
    {
        public BusinessCardRepository(IBusinessCardDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<BusinessCard> Find(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
