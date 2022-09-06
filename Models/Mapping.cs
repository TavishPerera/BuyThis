using AutoMapper;
using BuyThis.Data;
using BuyThis.ViewModels;

namespace BuyThis.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(ov => ov.OrderId,
                map => map.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItems, OrderItemViewModel>().ReverseMap()
                .ForMember(m => m.Product, opt => opt.Ignore());
        }
        
    }
}
