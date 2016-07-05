namespace MR.Assessment.DataModels.Foundation
{
    public class BaseAggregatedFilter
    {
        public BaseAggregatedFilter() : this(5)
        {

        }

        public BaseAggregatedFilter(int recordsCount)
        {
            RecordsCount = recordsCount;
        }

        public int RecordsCount { get; set; }
    }
}