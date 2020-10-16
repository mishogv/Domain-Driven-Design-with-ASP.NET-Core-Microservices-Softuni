namespace BCSystem.Infrastructure.BusinessCards.Repositories
{
    using BCSystem.Application.BusinessCards.BusinessMans;
    using BCSystem.Application.BusinessCards.BusinessMans.Queries.Details;
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using BCSystem.Domain.BusinessCards.Repositories;
    using BCSystem.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BusinessManRepository : DataRepository<IBusinessCardDbContext, BusinessMan>,                    IBusinessManQueryRepository,
            IBusinessManDomainRepository
    {
        public BusinessManRepository(IBusinessCardDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<BusinessMan> Find(string userId, CancellationToken cancellationToken = default)
            => await this.All().FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);

        public async Task<int> GetBusinessManId(string userId, CancellationToken cancellationToken = default)
            => await this.All()
                    .Where(x => x.UserId == userId)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync(cancellationToken);

        public async Task<BusinessManDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken)
        {
            var businessMan = await this.All()
                .Include(x => x.BusinessCards)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return new BusinessManDetailsOutputModel(businessMan.BusinessCards.Count, id, businessMan.Name, businessMan.PhoneNumber);
        }
    }
}
