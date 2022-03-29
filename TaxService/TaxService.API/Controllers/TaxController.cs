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
            try
            {
                if (location == null)
                {
                    _logger.LogInformation("Location is null", location);
                    return BadRequest("Location object is null.");
                }

                if (string.IsNullOrEmpty(location.Zip))
                {
                    _logger.LogInformation("Invalid Zip", location);
                    ModelState.AddModelError("Zip", "Zip is required");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogInformation("Invalid fields", location);
                    return BadRequest("Invalid fields.");
                }

                return Ok(await _taxServiceOp.GetRateByLocationAsync(location));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, location);
                return StatusCode(500, "Internal server error");
            }
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
            try
            {
                if (order == null)
                {
                    return BadRequest("order object is null");
                }

                if (string.IsNullOrEmpty(order.ToCountry))
                {
                    _logger.LogInformation("Invalid To Country", order);
                    ModelState.AddModelError("toCountry", "toCountry is required");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                return Ok(await _taxServiceOp.CalculateTaxByOrderAsync(order));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the CalculateTaxByOrder action: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
