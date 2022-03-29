using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxService.Application.DTOs;
using TaxService.Application.Interfaces;
using TaxService.Core.Models;

namespace TaxService.Application.Operations
{
    public class TaxOpService : IService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<TaxOpService> _logger;
        public TaxOpService(IRepository repository,
            IMapper mapper,
            ILogger<TaxOpService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Tax> CalculateTaxByOrderAsync(Order order)
        {
            var orderDto = _mapper.Map<OrderDTO>(order);
            var response = await _repository.CalculateTaxByOrderAsync(orderDto);

            var tax = _mapper.Map<Tax>(response.taxDto);
            if (tax == null)
                throw new AutoMapperMappingException($"Type of {typeof(Tax)} could not be mapped");
            return tax;
        }

        public async Task<Rate> GetRateByLocationAsync(Location location)
        {
            var response = await _repository.GetRateByLocationAsync(location);

            var rates = _mapper.Map<Rate>(response.rateDto);
            if (rates == null)
                throw new AutoMapperMappingException($"Type of {typeof(Rate)} could not be mapped");
            return rates;

        }


    }
}
