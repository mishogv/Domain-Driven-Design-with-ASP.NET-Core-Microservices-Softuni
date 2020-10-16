namespace BCSystem.Application.Statistics.Handlers
{
    using BCSystem.Application.Common;
    using BCSystem.Domain.BusinessCards.Events.BusinessMans;
    using BCSystem.Domain.Statistics.Repositories;
    using System.Threading.Tasks;

    public class BusinessCardAddedEventHandler : IEventHandler<BusinessCardAddedEvent>
    {
        private readonly IStatisticsDomainRepository statistics;

        public BusinessCardAddedEventHandler(IStatisticsDomainRepository statistics)
        {
            this.statistics = statistics;
        }
        public async Task Handle(BusinessCardAddedEvent domainEvent) 
            => await this.statistics.IncrementBusinessCards();
    }
}
