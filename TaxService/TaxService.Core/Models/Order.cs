using System.ComponentModel.DataAnnotations;

namespace TaxService.Core.Models
{
    public class Order
    {
        public string FromZip { get; set; }
        public string FromCountry { get; set; }
        public string FromState { get; set; }
        public string FromCity { get; set; }
        public string FromStreet { get; set; }
        public string ToZip { get; set; }
        [Required]
        public string ToCountry { get; set; }
        public string ToState { get; set; }
        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public decimal Amount { get; set; }
        public decimal Shipping { get; set; }
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();
    }
}
