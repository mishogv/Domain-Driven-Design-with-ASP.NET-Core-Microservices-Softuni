namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Common
{
    using BCSystem.Application.Common;
    using FluentValidation;
    using static BCSystem.Domain.BusinessCards.Models.ModelConstants.Common;
    using static BCSystem.Domain.BusinessCards.Models.ModelConstants.BusinessCard;

    public class BusinessCardCommonValidator<TCommand> : AbstractValidator<BusinessCardCommand<TCommand>>
           where TCommand : EntityCommand<int>
    {
        public BusinessCardCommonValidator()
        {
            this.RuleFor(x => x.CompanyName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(x => x.Description)
               .MinimumLength(MinDescriptionLength)
               .MaximumLength(MaxDescriptionLength)
               .NotEmpty();

            this.RuleFor(x => x.Address)
                .NotEmpty();
        }
    }
}
