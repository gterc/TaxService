namespace TaxService.Core.Models
{
    public class LineItem
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductTaxCode { get; set; }
    }
}
