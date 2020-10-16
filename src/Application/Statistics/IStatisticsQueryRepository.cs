﻿namespace BCSystem.Application.Statistics
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Statistics.Models;
    using Queries.Current;

    public interface IStatisticsQueryRepository : IQueryRepository<Statistics>
    {
        Task<GetCurrentStatisticsOutputModel> GetCurrent(CancellationToken cancellationToken = default);

        Task<int> GetBusinessCardViews(int businessCardId, CancellationToken cancellationToken = default);
    }
}
