using TaxService.Application.DTOs;
using TaxService.Core.Models;

namespace TaxService.Application.Interfaces
{
    public interface IRepository 
    {
        Task<RateResponse> GetRateByLocationAsync(Location location);
        Task<TaxResponse> CalculateTaxByOrderAsync(OrderDTO order);
    }
}
