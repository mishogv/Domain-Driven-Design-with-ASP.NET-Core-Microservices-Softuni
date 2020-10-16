namespace BCSystem.Application.BusinessCards.BusinessMans.Queries.Details
{
    using Common;

    public class BusinessManDetailsOutputModel : BusinessManOutputModel
    {
        public BusinessManDetailsOutputModel(int businessCardsCount, int id, string name, string phoneNumber)
            : base(id, name, phoneNumber)
        {
            this.BusinessCardsCount = businessCardsCount;
        }

        public int BusinessCardsCount { get; }
    }
}
