namespace BCSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using BCSystem.Domain.BusinessCards.Factories.BusinessMans;
    using BCSystem.Domain.BusinessCards.Repositories;
    using Common;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IBusinessManFactory businessManFactory;
            private readonly IBusinessManDomainRepository businessManRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IBusinessManFactory businessManFactory, 
                IBusinessManDomainRepository businessManDomainRepository)
            {
                this.identity = identity;
                this.businessManFactory = businessManFactory;
                this.businessManRepository = businessManDomainRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var businessMan = this.businessManFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .WithUserId(user.GetUserId())
                    .Build();

                await this.businessManRepository.Save(businessMan, cancellationToken);

                return result;
            }
        }
    }
}