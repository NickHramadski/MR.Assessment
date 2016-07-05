namespace MR.Assessment.DataModels.Specific.Brands
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public override string ToString()
        {
            return $"BrandId: '{BrandId}' | " +
                   $"BrandName: '{BrandName}'";
        }
    }
}