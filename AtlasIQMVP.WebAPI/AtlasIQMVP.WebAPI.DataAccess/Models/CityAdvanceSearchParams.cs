namespace AtlasIQMVP.WebAPI.DataAccess.Models
{
    public class CityAdvanceSearchParams
    {
        public string CityName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public double? MinimumSize { get; set; }
        public double? MaximumSize { get; set; }
        public string PropertyDescription { get; set; }
        public double? MinimumSalePrice { get; set; }
        public double? MaximumSalePrice { get; set; }
        public double? MinimumLeastCost { get; set; }
        public double? MaximumLeastCost { get; set; }
    }
}
