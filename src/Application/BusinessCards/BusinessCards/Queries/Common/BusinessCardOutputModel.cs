namespace BCSystem.Application.BusinessCards.BusinessCards.Queries.Common
{
    public class BusinessCardOutputModel
    {
        public BusinessCardOutputModel(int id, string logoUrl, string companyName, string description, string address, string siteUrl)
        {
            this.Id = id;
            this.LogoUrl = logoUrl;
            this.CompanyName = companyName;
            this.Description = description;
            this.Address = address;
            this.SiteUrl = siteUrl;
        }

        public int Id { get; }

        public string LogoUrl { get; }

        public string CompanyName { get; }

        public string Description { get; }

        public string Address { get; }

        public string SiteUrl { get; }
    }
}
