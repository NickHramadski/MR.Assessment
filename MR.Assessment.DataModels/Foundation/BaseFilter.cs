namespace MR.Assessment.DataModels.Foundation
{
    public class BaseFilter
    {
        public BaseFilter() : this(20)
        {

        }

        public BaseFilter(int? pageSize, int? pageNumber = null)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}