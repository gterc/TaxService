using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System.Collections.Generic;
using TaxService.API.Controllers;
using TaxService.API.Mapping;
using TaxService.Application.Interfaces;
using TaxService.Application.Operations;
using TaxService.Core.Models;
using TaxService.Insfrastructure;

namespace TaxService.Tests.Integration

{
    [TestFixture]
    public class TaxServiceTest
    {
        private TaxController _controller;
        private IService _taxService;
        private IRepository _repository;
        private IMapper _mapper;

        [OneTimeSetUp]
        public void Init()
        {
            var services = new ServiceCollection();
            services.AddTransient<IRepository, TaxJarApiService>();
            services.AddTransient<IService, TaxOpService>();
            services.AddLogging();
            var serviceProvider = services.BuildServiceProvider();

            _taxService = serviceProvider.GetService<IService>();

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var factory = serviceProvider.GetService<ILoggerFactory>();
            var taxLogger = factory.CreateLogger<TaxController>();
            //var serviceLogger = factory.CreateLogger<TaxOpService>();
            // _taxService = new TaxOpService(_repository, _mapper, serviceLogger);
            _controller = new TaxController(taxLogger, _taxService);
        }

        [Test]
        public void Should_get_bad_request_for_null_get_rate()
        {
            //Arrange
            Location location = null;

            //Act
            var response = _controller.GetRateByLocation(location);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result as BadRequestObjectResult);
        }

        [Test]
        public void Should_get_ok_request_for_get_rate()
        {
            //Arrange
            var location = new Location
            {
                City = "Miami",
                Country = "US",
                State = "FL",
                Street = "7th",
                Zip = "33071"
            };

            //Act
            var response = _controller.GetRateByLocation(location);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(response.Result as OkObjectResult);
        }

        [Test]
        public void Should_get_bad_request_for_invalid_get_rate()
        {
            //Arrange
            Location location = new Location
            {
                City = "Miami",
                Country = "US",
                State = "FL",
                Street = "7th"
            };

            //Act
            var response = _controller.GetRateByLocation(location);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result as BadRequestObjectResult);
        }

        [Test]
        public void Should_get_bad_request_for_null_calc_tax()
        {
            //Arrange
            Order order = null;

            //Act
            var response = _controller.CalculateTaxByOrder(order);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result as BadRequestObjectResult);
        }

        [Test]
        public void Should_get_ok_request_for_calc_tax()
        {
            //Arrange
            var order = new Order
            {
                Amount = (decimal)15.00,
                FromCity = "Miami",
                FromCountry = "US",
                ToCountry = "US",
                FromState = "FL",
                FromStreet = "7th",
                FromZip = "33071",
                Shipping = (decimal)1.00,
                ToCity = "Miami",
                ToState = "FL",
                ToStreet = "10th",
                ToZip = "33131",
                LineItems = new List<LineItem>()
                {
                    new LineItem(){
                        ProductTaxCode = 20010,
                        Quantity =1,
                        UnitPrice = (decimal)10.00
                    }
                }
            };

            //Act
            var response = _controller.CalculateTaxByOrder(order);

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(response.Result as OkObjectResult);
        }

        [Test]
        public void Should_get_bad_request_for_invalid_calc_tax()
        {
            //Arrange
            var order = new Order
            {
                Amount = (decimal)15.00,
                FromCity = "Miami",
            };

            //Act
            var response = _controller.CalculateTaxByOrder(order);

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result as BadRequestObjectResult);
        }
    }
}
