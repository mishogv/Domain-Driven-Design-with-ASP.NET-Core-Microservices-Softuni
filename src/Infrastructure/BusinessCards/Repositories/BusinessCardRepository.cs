namespace BCSystem.Infrastructure.BusinessCards.Repositories
{
    using BCSystem.Application.BusinessCards.BusinessCards;
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.BusinessCards.Repositories;
    using BCSystem.Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BusinessCardRepository : DataRepository<IBusinessCardDbContext, BusinessCard>,              IBusinessCardQueryRepository,
         IBusinessCardDomainRepository
    {
        public BusinessCardRepository(IBusinessCardDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<IEnumerable<BusinessCardOutputModel>> All(CancellationToken cancellationToken = default)
            => await this.Data.BusinessCards
                .Select(x => new BusinessCardOutputModel(x.Id, x.LogoUrl, x.CompanyName, x.Description, x.Address, x.SiteUrl))
                .ToListAsync(cancellationToken);

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var businessCard = await this.Data.BusinessCards.FindAsync(id, cancellationToken);

            if (businessCard == null)
            {
                return false;
            }

            this.Data.BusinessCards.Remove(businessCard);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<BusinessCard> Find(int id, CancellationToken cancellationToken = default)
            => await this.Data.BusinessCards.FindAsync(id, cancellationToken);

        public async Task<IEnumerable<BusinessCardOutputModel>> GetAllByCompanyName(string companyName, CancellationToken cancellationToken)
            => await this.Data.BusinessCards
                .Where(x => x.CompanyName == companyName)
                .Select(x => new BusinessCardOutputModel(x.Id, x.LogoUrl, x.CompanyName, x.Description, x.Address, x.SiteUrl))
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<BusinessCardOutputModel>> GetAllByUserId(string userId, CancellationToken cancellationToken)
        {
            var user = await this.Data.BusinessMens
                .Include(x => x.BusinessCards)
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync(cancellationToken);

            return user.BusinessCards.Select(x => new BusinessCardOutputModel(x.Id, x.LogoUrl, x.CompanyName, x.Description, x.Address, x.SiteUrl)).ToArray();
        }

        public async Task<BusinessCardOutputModel> GetDetails(int id, CancellationToken cancellationToken)
        {
            var businessCard = await this.Find(id);

            return new BusinessCardOutputModel(id, businessCard.LogoUrl, businessCard.CompanyName, businessCard.Description, businessCard.Address, businessCard.SiteUrl);
        }
    }
}
