namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Create
{
    using Common;
    using FluentValidation;

    public class CreateBusinessCardCommandValidator<TCommand> : AbstractValidator<CreateBusinessCardCommand>
    {
        public CreateBusinessCardCommandValidator() 
            => this.Include(new BusinessCardCommonValidator<CreateBusinessCardCommand>());
    }
}
