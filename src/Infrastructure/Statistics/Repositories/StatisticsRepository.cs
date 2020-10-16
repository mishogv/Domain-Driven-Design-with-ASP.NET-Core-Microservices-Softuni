namespace BCSystem.Infrastructure.Statistics.Repositories
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Statistics;
    using Application.Statistics.Queries.Current;
    using BCSystem.Domain.Statistics.Repositories;
    using Common.Persistence;
    using Domain.Statistics.Models;
    using Microsoft.EntityFrameworkCore;

    internal class StatisticsRepository : DataRepository<IStatisticsDbContext, Statistics>, IStatisticsQueryRepository, IStatisticsDomainRepository
    {
        public StatisticsRepository(IStatisticsDbContext db)
            : base(db)
        {
        }

        public async Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default)
        {
            var statistics = await this.All()
                .Include(x => x.BusinessCardViews)
                .SingleOrDefaultAsync(cancellationToken);

            return new GetCurrentStatisticsOutputModel(statistics.TotalBusinessCards, statistics.BusinessCardViews.Count);
        }

        public async Task<int> GetBusinessCardViews(int businessCardId, CancellationToken cancellationToken = default)
            => await this.Data
                .BusinessCardViews
                .CountAsync(cav => cav.BusinessCardId == businessCardId, cancellationToken);

        public async Task IncrementBusinessCards(CancellationToken cancellationToken = default)
        {
            var statistics = await this.Data
                .Statistics
                .SingleOrDefaultAsync(cancellationToken);

            statistics.AddBusinessCard();

            await this.Save(statistics, cancellationToken);
        }
    }
}
