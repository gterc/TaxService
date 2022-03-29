using AutoMapper;
using TaxService.Application.DTOs;
using TaxService.Core.Models;

namespace TaxService.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            CreateMap<RateDTO, Rate>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<LineItemDTO, LineItem>().ReverseMap();
            CreateMap<TaxDTO, Tax>()
                .ForMember(dest => dest.Amount , opt => opt.MapFrom(src => src.amount_to_collect))
                .ReverseMap();
        }
    }
}
