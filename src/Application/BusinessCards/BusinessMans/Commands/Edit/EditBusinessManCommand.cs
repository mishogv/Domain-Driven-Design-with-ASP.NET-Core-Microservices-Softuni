namespace BCSystem.Application.BusinessCards.BusinessMans.Commands.Edit
{
    using BCSystem.Application.Common;
    using BCSystem.Application.Common.Contracts;
    using BCSystem.Domain.BusinessCards.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditBusinessManCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditBusinessManCommandHandler : IRequestHandler<EditBusinessManCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IBusinessManDomainRepository businessManRepository;

            public EditBusinessManCommandHandler(ICurrentUser currentUser,
                IBusinessManDomainRepository businessManRepository)
            {
                this.currentUser = currentUser;
                this.businessManRepository = businessManRepository;
            }

            public async Task<Result> Handle(EditBusinessManCommand request, CancellationToken cancellationToken)
            {
                var userId = currentUser.UserId;
                var businessMan = await businessManRepository.Find(userId, cancellationToken);

                if (userId != businessMan.UserId)
                {
                    return "Wrong business man ID";
                }

                businessMan
                    .UpdatePhoneNumber(request.PhoneNumber)
                    .UpdateName(request.Name);

                await businessManRepository.Save(businessMan, cancellationToken);

                return Result.Success;
            }
        }
    }
}
