namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Create
{
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Factories.BusinessCards;
    using BCSystem.Domain.BusinessCards.Repositories;
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBusinessCardCommand : BusinessCardCommand<CreateBusinessCardCommand>, IRequest<CreateBusinessCardOutputModel>
    {
        public class CreateBusinessCardCommandHandler : IRequestHandler<CreateBusinessCardCommand, CreateBusinessCardOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBusinessCardDomainRepository businessCardRepository;
            private readonly IBusinessManDomainRepository businessManRepository;
            private readonly IBusinessCardFactory businessCardFactory;

            public CreateBusinessCardCommandHandler(
                ICurrentUser currentUser, 
                IBusinessCardDomainRepository businessCardRepository, 
                IBusinessManDomainRepository businessManRepository, 
                IBusinessCardFactory businessCardFactory)
            {
                this.currentUser = currentUser;
                this.businessCardRepository = businessCardRepository;
                this.businessManRepository = businessManRepository;
                this.businessCardFactory = businessCardFactory;
            }

            public async Task<CreateBusinessCardOutputModel> Handle(CreateBusinessCardCommand request, CancellationToken cancellationToken)
            {
                var businessMan = await this.businessManRepository.Find(this.currentUser.UserId, cancellationToken);

                var businessCard = this.businessCardFactory
                    .WithAddress(request.Address)
                    .WithCompanyName(request.CompanyName)
                    .WithDescription(request.Description)
                    .WithLogoUrl(request.LogoUrl)
                    .WithSiteUrl(request.SiteUrl)
                    .Build();

                businessMan.AddBusinessCard(businessCard);

                await this.businessCardRepository.Save(businessCard, cancellationToken);

                return new CreateBusinessCardOutputModel(businessCard.Id);
            }
        }
    }
}
