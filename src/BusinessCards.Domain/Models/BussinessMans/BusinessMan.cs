namespace BusinessCards.Domain.Models.BusinessMans
{
    using Common;
    using Exceptions;
    using Models.BusinessCards;
    using System.Collections.Generic;
    using System.Linq;

    using static ModelConstants.Username;

    public class BusinessMan : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<BusinessCard> businessCards;

        internal BusinessMan(string username, string phoneNumber)
        {
            this.Validate(username);

            this.Username = username;
            this.PhoneNumber = phoneNumber;

            this.businessCards = new HashSet<BusinessCard>();
        }

        public string Username { get; }

        public PhoneNumber PhoneNumber { get; private set; }

        public BusinessMan UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<BusinessCard> BusinessCards
            => this.businessCards.ToList().AsReadOnly();

        public void AddBusinessCard(BusinessCard businessCard)
            => this.businessCards.Add(businessCard);

        public void RemoveBusinessCard(BusinessCard businessCard)
            => this.businessCards.Remove(businessCard);

        public void RemoveByIdBusinessCard(int businessCardId)
        {
            var businessCard = this.businessCards.FirstOrDefault(x => x.Id == businessCardId);
            this.businessCards.Remove(businessCard);
        }

        private void Validate(string username)
            => Guard.ForStringLength<InvalidUsernameException>(username, MinNameLength, MaxNameLength, nameof(this.Username));
    }
}
