namespace BCSystem.Application.BusinessCards.BusinessMans.Queries.Common
{

    public class BusinessManOutputModel
    {
        public BusinessManOutputModel(int id, string name, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public int Id { get; }

        public string Name { get; }

        public string PhoneNumber { get; }
    }
}
