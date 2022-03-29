using TaxService.Core.Models;

namespace TaxService.Application.Interfaces
{
    public interface IService
    {
        Task<Rate> GetRateByLocationAsync(Location location);
        Task<Tax> CalculateTaxByOrderAsync(Order order);
    }
}
