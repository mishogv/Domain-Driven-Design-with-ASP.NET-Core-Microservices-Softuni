namespace BCSystem.Application.BusinessCards.BusinessCards.Comands.Create
{
    public class CreateBusinessCardOutputModel
    {
        public CreateBusinessCardOutputModel(int businessCardId)
            => this.BusinessCardId = businessCardId;

        public int BusinessCardId { get; }
    }
}
