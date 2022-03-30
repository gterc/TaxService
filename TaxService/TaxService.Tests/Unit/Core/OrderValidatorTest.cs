using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using TaxService.Core.Models;

namespace TaxService.Tests.Unit
{
    [TestFixture]
    public class OrderValidatorTest
    {
        private OrderValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new OrderValidator();
        }

        [Test]
        public void Should_have_error_when_ToCountry_is_null()
        {
            var model = new Order
            {
                ToZip = "07446",
                ToState = "NJ",
                Amount = (decimal)16.50,
                Shipping = (decimal)1.5
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(Order => Order.ToCountry);
        }

        [Test]
        public void Should_not_have_error_when_toCountry_is_specified()
        {
            var model = new Order
            {
                ToCountry = "US",
                ToZip = "07446",
                ToState = "NJ",
                Amount = (decimal)16.50,
                Shipping = (decimal)1.5
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(Order => Order.ToCountry);
        }

        //TODO: Test validate when Zip has letters, validate other fields
    }
}