namespace BCSystem.Domain.BusinessCards.Factories.BusinessCards
{
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;

    public class BusinessCardFactory : IBusinessCardFactory
    {
        private string address = default!;
        private string companyName = default!;
        private string logoUrl = default!;
        private string description = default!;
        private string siteUrl = default!;
        public BusinessCard Build()
            => new BusinessCard(logoUrl, companyName, description, address, siteUrl);

        public IBusinessCardFactory WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public IBusinessCardFactory WithCompanyName(string name)
        {
            this.companyName = name;
            return this;
        }

        public IBusinessCardFactory WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public IBusinessCardFactory WithLogoUrl(string logoUrl)
        {
            this.logoUrl = logoUrl;
            return this;
        }

        public IBusinessCardFactory WithSiteUrl(string siteUrl)
        {
            this.siteUrl = siteUrl;
            return this;
        }
    }
}
