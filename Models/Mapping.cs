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
                .ForMember(ov => ov.Id,
                map => map.MapFrom(o => o.OrderId))
                .ReverseMap();

            CreateMap<OrderItems, OrderViewModel>().ReverseMap();
        }
        
    }
}
