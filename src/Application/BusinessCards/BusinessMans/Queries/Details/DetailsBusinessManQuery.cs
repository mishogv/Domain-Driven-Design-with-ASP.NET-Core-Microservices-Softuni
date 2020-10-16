namespace BCSystem.Application.BusinessCards.BusinessMans.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DetailsBusinessManQuery : IRequest<BusinessManDetailsOutputModel>
    {
        public int Id { get; set; }

        public class DetailsBusinessManQueryHandler : IRequestHandler<DetailsBusinessManQuery, BusinessManDetailsOutputModel>
        {
            private readonly IBusinessManQueryRepository businessManRepository;

            public DetailsBusinessManQueryHandler(IBusinessManQueryRepository businessManRepository)
                => this.businessManRepository = businessManRepository;

            public async Task<BusinessManDetailsOutputModel> Handle(
                DetailsBusinessManQuery request,
                CancellationToken cancellationToken)
                => await this.businessManRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
