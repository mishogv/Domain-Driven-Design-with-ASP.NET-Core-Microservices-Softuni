namespace BCSystem.Application.BusinessCards.BusinessCards.Queries.Details
{
    using MediatR;
    using Common;
    using System.Threading.Tasks;
    using System.Threading;

    public class DetailsBusinessCardQuery : IRequest<BusinessCardOutputModel>
    {
        public int Id { get; set; }

        public class DetailsBusinessCardQueryHandler : IRequestHandler<DetailsBusinessCardQuery, BusinessCardOutputModel>
        {
            private readonly IBusinessCardQueryRepository businessCardRepository;

            public DetailsBusinessCardQueryHandler(IBusinessCardQueryRepository businessCardRepository)
                => this.businessCardRepository = businessCardRepository;

            public async Task<BusinessCardOutputModel> Handle(
                DetailsBusinessCardQuery request,
                CancellationToken cancellationToken)
                => await this.businessCardRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
