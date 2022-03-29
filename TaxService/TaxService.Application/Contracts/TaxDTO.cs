using Newtonsoft.Json;

namespace TaxService.Application.DTOs
{
    public class TaxDTO
    {
        public TaxDTO()
        {

        }
        public string amount_to_collect { get; set; }
    }
    public class TaxResponse 
    {
        public TaxResponse()
        {

        }
        [JsonProperty("tax")]
        public TaxDTO taxDto { get; set; }
    }
}
