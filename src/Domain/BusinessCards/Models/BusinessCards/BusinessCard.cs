namespace BCSystem.Domain.BusinessCards.Models.BusinessCards
{
    using BCSystem.Domain.BusinessCards.Exceptions;
    using BCSystem.Domain.Common;
    using BCSystem.Domain.Common.Models;
    using static ModelConstants.Common;
    using static ModelConstants.BusinessCard;

    public class BusinessCard : Entity<int>, IAggregateRoot
    {
        internal BusinessCard(string logoUrl, string companyName, string description, string address, string siteUrl)
        {
            // TODO: Validate all props
            this.ValidateCompanyName(companyName);
            this.ValidateDescription(description);
            this.LogoUrl = logoUrl;
            this.CompanyName = companyName;
            this.Description = description;
            this.Address = address;
            this.SiteUrl = siteUrl;
        }

        private BusinessCard()
        {
            this.LogoUrl = default!;
            this.CompanyName = default!;
            this.Description = default!;
            this.Address = default!;
            this.SiteUrl = default!;
        }

        public string LogoUrl { get; private set; }

        public string CompanyName { get; private set; }

        public string Description { get; private set; }

        public string Address { get; private set; }

        public string SiteUrl { get; private set; }

        public BusinessCard UpdateLogoUrl(string logoUrl)
        {
            this.LogoUrl = logoUrl;

            return this;
        }

        public BusinessCard UpdateCompanyName(string companyName)
        {
            this.ValidateCompanyName(companyName);
            this.CompanyName = companyName;

            return this;
        }

        public BusinessCard UpdateDescription(string description)
        {
            this.ValidateDescription(description);
            this.Description = description;

            return this;
        }

        private void ValidateCompanyName(string companyName)
            => Guard.ForStringLength<InvalidCompanyNameException>(
                companyName,
                MinNameLength,
                MaxNameLength,
                nameof(CompanyName));

        private void ValidateDescription(string description)
         => Guard.ForStringLength<InvalidDescriptionException>(
             description,
             MinDescriptionLength,
             MaxDescriptionLength,
             nameof(Description));
    }
}
