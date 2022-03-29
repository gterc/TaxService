using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaxService.Core.Models;

namespace TaxService.Insfrastructure
{
    public interface IRepository
    {
        //Task AddAsync<T>(T entity, string requestUri);
        //Task<HttpStatusCode> DeleteAsync(string requestUri);
        //Task EditAsync<T>(T t, string requestUri);
        Task<T> GetRateByLocationAsync<T>(Location location);
        Task<T> CalculateTaxByOrderAsync<T>(string path);
    }
}
