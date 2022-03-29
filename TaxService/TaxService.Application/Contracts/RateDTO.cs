using Newtonsoft.Json;

namespace TaxService.Application.DTOs
{
    public class RateDTO
    {
        public string city { get; set; }
        public string city_rate { get; set; } = "0.0";
        public string combined_district_rate { get; set; } = "0.0";
        public string combined_rate { get; set; } = "0.0";
        public string country { get; set; }
        public string country_rate { get; set; } = "0.0";
        public string county { get; set; }
        public string county_rate { get; set; } = "0.0";
        public bool freight_taxable { get; set; }
        public string state { get; set; }
        public string state_rate { get; set; }
        public string zip { get; set; }
    }
    public class RateResponse 
    {
        [JsonProperty("rate")]
        public RateDTO rateDto { get; set; }
    }
}
