namespace BCSystem.Application.Statistics.Queries.Current
{
    public class GetCurrentStatisticsOutputModel
    {
        public GetCurrentStatisticsOutputModel(int totalBusinessCards, int totalBusinessCardViews)
        {
            this.TotalBusinessCards = totalBusinessCards;
            this.TotalBusinessCardViews = totalBusinessCardViews;
        }

        public int TotalBusinessCards { get; }

        public int TotalBusinessCardViews { get; }
    }
}
