// using Iso.Backend.Application.DTO.;

using Iso.Backend.Application.DTO.Items;

namespace Iso.Backend.Application.Services.Orders.Interfaces
{
    public interface IItemsService
    {
        public Task<IEnumerable<ItemResponseDTO>> GetItems(
            int page = 1,
            int pageSize = 10,
            string orderBy = "Name",
            string orderDirection = "asc",
            string search = null,
            Guid? categoryId = null
        );

        public Task<ItemResponseDTO> GetItem(Guid id);
        public Task<ItemResponseDTO> CreateItem(ItemCreateDTO item);
        public Task<ItemResponseDTO> UpdateItem(Guid id, ItemCreateDTO item);
        public Task<ItemResponseDTO> DeleteItem(Guid id);
        
    }
}