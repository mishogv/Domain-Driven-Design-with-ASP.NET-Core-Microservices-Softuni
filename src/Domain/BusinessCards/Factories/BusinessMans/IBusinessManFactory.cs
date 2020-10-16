namespace BCSystem.Domain.BusinessCards.Factories.BusinessMans
{
    using BCSystem.Domain.BusinessCards.Models.BusinessMans;
    using BCSystem.Domain.Common;

    public interface IBusinessManFactory : IFactory<BusinessMan>
    {
        IBusinessManFactory WithName(string name);

        IBusinessManFactory WithPhoneNumber(string phoneNumber);

        IBusinessManFactory WithUserId(string userId);
    }
}
