using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxService.Core.DTOs
{
    [Serializable]
    public class RateDTO
    {
        [JsonProperty("zip")]
        public int Zip { get; set; }
        public string State { get; set; }
        public decimal StateRate { get; set; }
        public string County { get; set; }
        public decimal CountyRate { get; set; }
        public string City { get; set; }
        public decimal CityRate { get; set; }
        public decimal CombinedDistrictRate { get; set; }
        public decimal CombinedRate { get; set; }
        public bool FreightTaxable { get; set; }
 "rate": {
    "zip": "90404",
    "state": "CA",
    "state_rate": "0.0625",
    "county": "LOS ANGELES",
    "county_rate": "0.01",
    "city": "SANTA MONICA",
    "city_rate": "0.0",
    "combined_district_rate": "0.025",
    "combined_rate": "0.0975",
    "freight_taxable": false
  }
    }
}
