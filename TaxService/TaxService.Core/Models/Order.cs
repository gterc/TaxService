using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TaxService.Core.Models
{
    public class Order
    {
        public string FromZip { get; set; }
        public string FromCountry { get; set; }
        public string FromState { get; set; }
        public string ToZip { get; set; }
        [Required]
        public string ToCountry { get; set; }
        public string ToState { get; set; }
        public decimal Amount { get; set; }
        [Required]
        public decimal Shipping { get; set; }
        public List<LineItem> LineItems { get; set; }
    }

    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(model => model.FromZip)
                .NotEqual("string")
                .MinimumLength(5);
            RuleFor(model => model.FromCountry)
                .NotEqual("string")
                .MinimumLength(2);
            RuleFor(model => model.FromState)
                .NotEqual("string")
                .MaximumLength(2)
                .MinimumLength(2);
            RuleFor(model => model.ToZip)
                .NotEqual("string")
                .MinimumLength(5);
            RuleFor(model => model.ToCountry)
                .NotEmpty()
                .NotEqual("string")
                .MinimumLength(2);
            RuleFor(model => model.ToState)
                .NotEqual("string")
                .MaximumLength(2)
                .MinimumLength(2);
            RuleFor(model => model.Amount)
                .GreaterThan(0);
            RuleFor(model => model.Shipping)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .ToString();
        }
    }
}
