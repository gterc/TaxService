namespace TaxService.Core.Models
{
    public class LineItemDTO
    {
        public int quantity { get; set; }
        public decimal unit_price { get; set; }
        public int product_tax_code { get; set; }
    }
}
