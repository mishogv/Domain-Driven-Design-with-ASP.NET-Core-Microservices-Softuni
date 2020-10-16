namespace BCSystem.Application.BusinessCards.BusinessMans.Commands.Edit
{
    using FluentValidation;
    using static Domain.BusinessCards.Models.ModelConstants.Common;
    using static Domain.BusinessCards.Models.ModelConstants.PhoneNumber;

    public class EditBusinessManCommandValidator : AbstractValidator<EditBusinessManCommand>
    {
        public EditBusinessManCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
