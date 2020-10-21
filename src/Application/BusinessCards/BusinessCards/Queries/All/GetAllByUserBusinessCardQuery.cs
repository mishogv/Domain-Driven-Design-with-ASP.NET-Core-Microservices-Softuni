namespace BCSystem.Application.BusinessCards.BusinessCards.Queries.All
{
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllByUserBusinessCardQuery : IRequest<IEnumerable<BusinessCardOutputModel>>
    {
        public string UserId { get; set; } = default!;

        public class AllByUserBusinessCardQueryHandler : IRequestHandler<GetAllByUserBusinessCardQuery, IEnumerable<BusinessCardOutputModel>>
        {
            private readonly IBusinessCardQueryRepository businessCardRepository;

            public AllByUserBusinessCardQueryHandler(IBusinessCardQueryRepository businessCardRepository)
                => this.businessCardRepository = businessCardRepository;

            public async Task<IEnumerable<BusinessCardOutputModel>> Handle(GetAllByUserBusinessCardQuery request, CancellationToken cancellationToken)
                => await this.businessCardRepository.GetAllByUserId(request.UserId, cancellationToken);
        }
    }
}
