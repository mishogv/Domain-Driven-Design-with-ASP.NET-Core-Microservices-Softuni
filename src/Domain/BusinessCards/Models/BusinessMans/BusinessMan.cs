namespace BCSystem.Domain.BusinessCards.Models.BusinessMans
{
    using System.Collections.Generic;
    using System.Linq;
    using BCSystem.Domain.BusinessCards.Events.BusinessMans;
    using BCSystem.Domain.BusinessCards.Exceptions;
    using BCSystem.Domain.BusinessCards.Models.BusinessCards;
    using Common;
    using Common.Models;
    using static ModelConstants.Common;

    public class BusinessMan : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<BusinessCard> businessCards;

        internal BusinessMan(string name, string phoneNumber, string userId)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.UserId = userId;

            this.businessCards = new HashSet<BusinessCard>();
        }

        private BusinessMan(string name)
        {
            this.Validate(name);

            this.Name = name;
            this.PhoneNumber = default!;
            this.UserId = default!;

            this.businessCards = new HashSet<BusinessCard>();
        }

        public string UserId { get; private set; }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public BusinessMan UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public BusinessMan UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public IReadOnlyCollection<BusinessCard> BusinessCards => this.businessCards.ToList().AsReadOnly();

        public void AddBusinessCard(BusinessCard businessCard)
        {
            this.businessCards.Add(businessCard);
            this.RaiseEvent(new BusinessCardAddedEvent());
        }

        public void RemoveBusinessCard(int id)
            => this.businessCards.Remove(this.businessCards.FirstOrDefault(x => x.Id == id));

        private void Validate(string name)
            => Guard.ForStringLength<InvalidBusinessManNameException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));
    }
}
