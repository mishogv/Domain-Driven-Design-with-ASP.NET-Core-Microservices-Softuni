namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Delete
{
    using BCSystem.Application.Common;
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Repositories;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteBusinessCardCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteBusinessCardCommandHandler : IRequestHandler<DeleteBusinessCardCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBusinessCardDomainRepository businessCardRepository;
            private readonly IBusinessManDomainRepository businessManRepository;

            public DeleteBusinessCardCommandHandler(
                ICurrentUser currentUser,
                IBusinessCardDomainRepository businessCardRepository,
                IBusinessManDomainRepository businessManRepository)
            {
                this.currentUser = currentUser;
                this.businessCardRepository = businessCardRepository;
                this.businessManRepository = businessManRepository;
            }

            public async Task<Result> Handle(DeleteBusinessCardCommand request, CancellationToken cancellationToken)
            {
                var businessMan = await this.businessManRepository.Find(this.currentUser.UserId, cancellationToken);

                if (businessMan.BusinessCards.FirstOrDefault(x => x.Id == request.Id) == null)
                {
                    return "This business card is not yours!!!";
                }

                businessMan.RemoveBusinessCard(request.Id);

                await this.businessCardRepository.Delete(request.Id, cancellationToken);

                return Result.Success;
            }
        }
    }
}
