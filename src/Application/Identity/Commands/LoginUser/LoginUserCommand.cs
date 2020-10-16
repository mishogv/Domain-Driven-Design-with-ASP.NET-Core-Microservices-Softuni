namespace BCSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using BCSystem.Domain.BusinessCards.Repositories;
    using Common;
    using MediatR;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly IBusinessManDomainRepository businessManDomainRepository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IBusinessManDomainRepository businessManDomainRepository)
            {
                this.identity = identity;
                this.businessManDomainRepository = businessManDomainRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var businessManId = await this.businessManDomainRepository.GetBusinessManId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, businessManId);
            }
        }
    }
}
