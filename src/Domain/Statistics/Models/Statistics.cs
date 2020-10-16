namespace BCSystem.Domain.Statistics.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Statistics : IAggregateRoot
    {
        private readonly HashSet<BusinessCardView> businessCardViews;

        internal Statistics()
        {
            this.TotalBusinessCards = 0;

            this.businessCardViews = new HashSet<BusinessCardView>();
        }

        public int TotalBusinessCards { get; private set; }

        public IReadOnlyCollection<BusinessCardView> BusinessCardViews
            => this.businessCardViews.ToList().AsReadOnly();

        public void AddBusinessCard()
            => this.TotalBusinessCards++;

        public void AddBusinessCardView(int businessCardId, string? userId)
            => this.businessCardViews.Add(new BusinessCardView(businessCardId, userId));
    }
}
