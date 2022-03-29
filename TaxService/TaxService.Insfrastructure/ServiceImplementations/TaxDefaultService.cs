using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using TaxService.Application.DTOs;
using TaxService.Application.Interfaces;
using TaxService.Core.Models;

namespace TaxService.Insfrastructure
{
    public class TaxDefaultService : IRepository
    {
        public Task<TaxResponse> CalculateTaxByOrderAsync(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task<RateResponse> GetRateByLocationAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}