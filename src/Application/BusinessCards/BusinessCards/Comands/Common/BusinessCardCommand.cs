namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Common
{
    using BCSystem.Application.Common;

    public class BusinessCardCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string LogoUrl { get; private set; } = default!;

        public string CompanyName { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public string Address { get; private set; } = default!;

        public string SiteUrl { get; private set; } = default!;
    }
}
