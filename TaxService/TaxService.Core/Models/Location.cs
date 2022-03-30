using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace TaxService.Core.Models
{
    public class Location
    {
        [Required]
        public int Zip { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(model => model.Zip)
                .NotNull()
                .NotEmpty()
                .LessThan(99999)
                .GreaterThan(0)
                .ToString();
            RuleFor(model => model.Country)
                .NotEqual("string")
                .MinimumLength(2);
            RuleFor(model => model.State)
                .NotEqual("string")
                .MaximumLength(2)
                .MinimumLength(2);
            RuleFor(model => model.City)
                .NotEqual("string")
                .MinimumLength(2);
            RuleFor(model => model.Street)
                .NotEqual("string")
                .MinimumLength(2);
                
        }
    }
}
