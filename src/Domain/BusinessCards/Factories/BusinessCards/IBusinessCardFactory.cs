namespace BCSystem.Domain.BusinessCards.Factories.BusinessCards
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using BCSystem.Domain.Common;

    public interface IBusinessCardFactory : IFactory<BusinessCard>
    {
        IBusinessCardFactory WithCompanyName(string name);

        IBusinessCardFactory WithLogoUrl(string logoUrl);

        IBusinessCardFactory WithDescription(string description);

        IBusinessCardFactory WithAddress(string address);

        IBusinessCardFactory WithSiteUrl(string siteUrl);
    }
}
