using Microsoft.AspNetCore.Mvc;
using TaxService.Application.Interfaces;
using TaxService.Core.Models;

namespace TaxService.API.Controllers
{
    /// <summary>
    /// Service to get tax rate and tax calculation for an order.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly IService _taxServiceOp;

        public TaxController(ILogger<TaxController> logger,
            IService taxServiceOp)
        {
            _logger = logger;
            _taxServiceOp = taxServiceOp;
        }

        /// <summary>
        /// Gets the tax rate by location.
        /// </summary>
        /// <param name="location">The location desired to get the tax rate for.</param>
        /// <returns>Rates for city, state, country, and combine rate.</returns>
        [HttpGet]
        [Route("rate")]
        public async Task<ActionResult> GetRateByLocation([FromQuery] Location location)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid fields", location);
                return BadRequest("Invalid fields");
            }
            _logger.LogInformation("Calling service", location);
            return Ok(await _taxServiceOp.GetRateByLocationAsync(location));
        }

        /// <summary>
        /// Calculates the tax for a given order
        /// </summary>
        /// <param name="order">Order Details to which calculate tax for.</param>
        /// <returns>Tax Ammount for the order.</returns>
        [HttpPost]
        [Route("tax")]
        public async Task<ActionResult> CalculateTaxByOrder([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            return Ok(await _taxServiceOp.CalculateTaxByOrderAsync(order));
        }
    }
}
