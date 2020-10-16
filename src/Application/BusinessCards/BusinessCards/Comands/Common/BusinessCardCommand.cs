namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Common
{
    using BCSystem.Application.Common;

    public class BusinessCardCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string LogoUrl { get; set; } = default!;

        public string CompanyName { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Address { get; set; } = default!;

        public string SiteUrl { get; set; } = default!;
    }
}
