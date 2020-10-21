namespace BCSystem.Application.BusinessCards.BusinessCards.Queries.All
{
    using BCSystem.Application.BusinessCards.BusinessCards.Queries.Common;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAllByCompanyNameBusinessCardQuery : IRequest<IEnumerable<BusinessCardOutputModel>>
    {
        public string CompanyName { get; set; } = default!;

        public class GetAllByCompanyNameBusinessCardQueryHandler : IRequestHandler<GetAllByCompanyNameBusinessCardQuery, IEnumerable<BusinessCardOutputModel>>
        {
            private readonly IBusinessCardQueryRepository businessCardRepository;

            public GetAllByCompanyNameBusinessCardQueryHandler(IBusinessCardQueryRepository businessCardRepository)
                => this.businessCardRepository = businessCardRepository;

            public async Task<IEnumerable<BusinessCardOutputModel>> Handle(GetAllByCompanyNameBusinessCardQuery request, CancellationToken cancellationToken)
                => await this.businessCardRepository.GetAllByCompanyName(request.CompanyName, cancellationToken);
        }
    }
}
