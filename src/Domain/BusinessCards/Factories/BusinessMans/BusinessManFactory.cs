namespace BCSystem.Domain.BusinessCards.Factories.BusinessMans
{
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;

    public class BusinessManFactory : IBusinessManFactory
    {
        private string name = default!;
        private string phoneNumber = default!;
        private string userId = default!;

        public BusinessMan Build()
            => new BusinessMan(this.name, this.phoneNumber, this.userId);

        public IBusinessManFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IBusinessManFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public IBusinessManFactory WithUserId(string userId)
        {
            this.userId = userId;
            return this;
        }
    }
}
