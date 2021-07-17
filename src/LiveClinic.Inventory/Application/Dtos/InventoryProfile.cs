using AutoMapper;
using LiveClinic.Inventory.Domain;

namespace LiveClinic.Inventory.Application.Dtos
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Drug, InventoryDto>();
        }
    }
}