namespace BCSystem.Domain.Statistics.Repositories
{
    using BCSystem.Domain.Statistics.Models;
    using BCSystem.Domain.Common;
    using System.Threading.Tasks;
    using System.Threading;

    public interface IStatisticsDomainRepository : IDomainRepository<Statistics>
    {
        Task IncrementBusinessCards(CancellationToken cancellationToken = default);
    }
}
