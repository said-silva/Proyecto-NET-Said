namespace Proyecto_NET.Utilities
{
    public class QueryFilter
    {
        public string color { get; set; }
        public string orderBy { get; set; }
        public string name { get; set; }
        public string productNumber { get; set; }
        public string productId { get; set; }
        public PriceFilter priceFilter { get; set; }
    }
}