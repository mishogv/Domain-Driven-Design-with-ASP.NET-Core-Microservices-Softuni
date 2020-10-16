namespace BCSystem.Domain.Statistics.Models
{
    using Common.Models;

    public class BusinessCardView : Entity<int>
    {
        internal BusinessCardView(int businessCardId, string? userId)
        {
            this.BusinessCardId = businessCardId;
            this.UserId = userId;
        }

        public int BusinessCardId { get; }

        public string? UserId { get; }
    }
}
