using AutoMapper;
using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Web.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Item, ItemResponseDTO>();
        CreateMap<Item, ItemResponseDTO>().ReverseMap();
        CreateMap<ItemCreateDTO, Item>();
        CreateMap<ItemCreateDTO, Item>().ReverseMap();
    }
}