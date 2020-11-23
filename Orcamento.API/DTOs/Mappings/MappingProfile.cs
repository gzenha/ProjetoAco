using AutoMapper;
using Orcamento.API.Models;

namespace Orcamento.API.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>().ReverseMap();
            CreateMap<ListaItem, ListaItemDTO>().ReverseMap();
            CreateMap<Tborcamento, TbOrcamentoDTO>().ReverseMap();
        }

    }
}