namespace MR.Assessment.DataModels.Specific.Ads
{
    public class AdViewModel
    {
        public int AdId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public decimal NumPages { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"AdId: '{AdId}' | " +
                   $"BrandId: '{BrandId}' | " +
                   $"BrandName: '{BrandName}' | " +
                   $"NumPages: '{NumPages}' | " +
                   $"Position: '{Position}'";
        }
    }
}