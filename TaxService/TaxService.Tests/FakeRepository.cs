using System.Threading.Tasks;
using TaxService.Application.DTOs;
using TaxService.Application.Interfaces;
using TaxService.Core.Models;

namespace TaxService.Tests
{
    public class FakeRepository : IRepository
    {
        private readonly TaxResponse _taxResponse;
        private readonly RateResponse _rateResponse;
        public FakeRepository()
        {
            _taxResponse = new TaxResponse()
            {
                taxDto = new TaxDTO
                {
                    amount_to_collect = (5.00).ToString()
                } 
            };
            _rateResponse = new RateResponse()
            {
                rateDto = new RateDTO()
                {
                    city = "Miami",
                    city_rate = ".07",
                    combined_rate = ".07",
                    state = "FL",
                    country = "US"
                }
            };
        }
        public Task<TaxResponse> CalculateTaxByOrderAsync(OrderDTO order)
        {
            return Task.FromResult(_taxResponse);
        }

        public Task<RateResponse> GetRateByLocationAsync(Location location)
        {
            return Task.FromResult(_rateResponse);
        }
    }
}
