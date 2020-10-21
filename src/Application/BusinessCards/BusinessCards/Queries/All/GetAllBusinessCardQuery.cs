namespace BCSystem.Application.BusinessCards.BusinessCards.Queries.All
{
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AllBusinessCardQuery : IRequest<IEnumerable<BusinessCardOutputModel>>
    {
        public class AllBusinessCardQueryHandler : IRequestHandler<AllBusinessCardQuery, IEnumerable<BusinessCardOutputModel>>
        {
            private readonly IBusinessCardQueryRepository businessCardRepository;

            public AllBusinessCardQueryHandler(IBusinessCardQueryRepository businessCardRepository)
                => this.businessCardRepository = businessCardRepository;

            public async Task<IEnumerable<BusinessCardOutputModel>> Handle(AllBusinessCardQuery request, CancellationToken cancellationToken)
                => await this.businessCardRepository.All(cancellationToken);
        }
    }
}
