namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Edit
{
    using Common;
    using FluentValidation;

    public class EditBusinessCardCommandValidator<TCommnad> : AbstractValidator<EditBusinessCardCommand>
    {
        public EditBusinessCardCommandValidator()
            => this.Include(new BusinessCardCommonValidator<EditBusinessCardCommand>());
    }
}
