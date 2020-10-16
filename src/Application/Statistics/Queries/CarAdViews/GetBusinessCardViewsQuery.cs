namespace BCSystem.Application.Statistics.Queries.CarAdViews
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetBusinessCardViewsQuery : IRequest<int>
    {
        public int BusinessCardId { get; set; }

        public class GetCarAdViewsQueryHandler : IRequestHandler<GetBusinessCardViewsQuery, int>
        {
            private readonly IStatisticsQueryRepository statistics;

            public GetCarAdViewsQueryHandler(IStatisticsQueryRepository statistics) 
                => this.statistics = statistics;

            public Task<int> Handle(
                GetBusinessCardViewsQuery request, 
                CancellationToken cancellationToken)
                => this.statistics.GetBusinessCardViews(request.BusinessCardId, cancellationToken);
        }
    }
}
