namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Edit
{
    using Common;
    using BCSystem.Application.Common;
    using MediatR;
    using System.Threading.Tasks;
    using System.Threading;
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Repositories;
    using BCSystem.Domain.BusinessCards.Factories.BusinessCards;
    using System.Linq;

    public class EditBusinessCardCommand : BusinessCardCommand<EditBusinessCardCommand>, IRequest<Result>
    {
        public class EditBusinessCardCommandHandler : IRequestHandler<EditBusinessCardCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBusinessCardDomainRepository businessCardRepository;
            private readonly IBusinessManDomainRepository businessManRepository;

            public EditBusinessCardCommandHandler(
                ICurrentUser currentUser,
                IBusinessCardDomainRepository businessCardRepository,
                IBusinessManDomainRepository businessManRepository)
            {
                this.currentUser = currentUser;
                this.businessCardRepository = businessCardRepository;
                this.businessManRepository = businessManRepository;
            }

            public async Task<Result> Handle(EditBusinessCardCommand request, CancellationToken cancellationToken)
            {
                var businessMan = await this.businessManRepository.Find(this.currentUser.UserId, cancellationToken);

                if (businessMan.BusinessCards.FirstOrDefault(x => x.Id == request.Id) == null)
                {
                    return "This business card is not yours!!!";
                }

                var businessCard = await this.businessCardRepository.Find(request.Id, cancellationToken);

                businessCard.UpdateCompanyName(request.CompanyName);
                businessCard.UpdateDescription(request.Description);
                businessCard.UpdateLogoUrl(request.LogoUrl);

                await this.businessCardRepository.Save(businessCard, cancellationToken);

                return Result.Success;
            }
        }
    }
}
