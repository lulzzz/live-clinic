using AutoMapper;
using LiveClinic.Inventory.Core.Domain;

namespace LiveClinic.Inventory.Core.Application.Dtos
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<StockTransaction, StockTransactionDto>();
            CreateMap<Drug, InventoryDto>();
        }
    }
}
