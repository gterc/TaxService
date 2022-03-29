namespace TaxService.Core.Models
{
    public class Rate
    {
        
        public int Zip { get; set; }

        public string State { get; set; } = string.Empty;

        public decimal StateRate { get; set; }

        public string County { get; set; } = string.Empty;

        public decimal CountyRate { get; set; }

        public string City { get; set; } = string.Empty;

        public decimal CityRate { get; set; }

        public decimal CombinedDistrictRate { get; set; }

        public decimal CombinedRate { get; set; }

        public bool FreightTaxable { get; set; }
    }
}
