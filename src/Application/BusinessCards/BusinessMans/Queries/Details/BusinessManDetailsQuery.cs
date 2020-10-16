namespace BCSystem.Application.BusinessCards.BusinessMans.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class BusinessManDetailsQuery : IRequest<BusinessManDetailsOutputModel>
    {
        public int Id { get; set; }

        public class BusinessManDetailsQueryHandler : IRequestHandler<BusinessManDetailsQuery, BusinessManDetailsOutputModel>
        {
            private readonly IBusinessManQueryRepository businessManRepository;

            public BusinessManDetailsQueryHandler(IBusinessManQueryRepository dealerRepository)
                => this.businessManRepository = dealerRepository;

            public async Task<BusinessManDetailsOutputModel> Handle(
                BusinessManDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.businessManRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
