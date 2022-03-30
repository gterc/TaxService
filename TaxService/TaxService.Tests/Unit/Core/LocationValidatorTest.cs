using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using TaxService.Core.Models;

namespace TaxService.Tests.Unit
{
    [TestFixture]
    public class LocationValidatorTest
    {
        private LocationValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new LocationValidator();
        }

        [Test]
        public void Should_have_error_when_zip_is_zero()
        {
            var model = new Location
            {
                Zip = 0,
                City = "Miami",
                Country = "US",
                State = "FL",
                Street = "7th"
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(location => location.Zip);
        }

        [Test]
        public void Should_not_have_error_when_zip_is_specified()
        {
            var model = new Location
            {
                Zip = 33071,
                City = "Miami",
                Country = "US",
                State = "FL",
                Street = "7th"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(location => location.Zip);
        }

        //TODO: Test validate when Zip has letters, validate other fields
    }
}