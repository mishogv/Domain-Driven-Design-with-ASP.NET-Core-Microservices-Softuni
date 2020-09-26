namespace BusinessCards.Domain.Models.BusinessCards
{
    using Common;

    public class BusinessCard : Entity<int>, IAggregateRoot
    {
        internal BusinessCard(string companyName)
        {
            this.CompanyName = companyName;
        }

        public string CompanyName { get; private set; }
    }
}
