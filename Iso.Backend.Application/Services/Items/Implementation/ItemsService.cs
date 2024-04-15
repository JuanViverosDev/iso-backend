using AutoMapper;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.Services.Orders.Implementation
{
    public class ItemsService : IItemsService
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemsService(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemResponseDTO>> GetItems(
            int page = 1,
            int pageSize = 10,
            string orderBy = "Name",
            string orderDirection = "asc",
            string search = null,
            Guid? categoryId = null
        )
        {
            try
            {
                var query = await _itemRepository.FindAsync(i => i.IsActive == true && i.IsDeleted == false);
                if (categoryId.HasValue)
                {
                    query = query.Where(item => item.CategoryId == categoryId);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(item => item.Name.Contains(search));
                }

                var totalItems = query.Count();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
                if (string.IsNullOrEmpty(orderBy))
                    orderBy = "Name";
                query = ApplySorting(query, orderBy, orderDirection);
                query = query.Skip((page - 1) * pageSize).Take(pageSize);
                var items = _mapper.Map<IEnumerable<ItemResponseDTO>>(query);
                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los items", ex);
            }
        }

        private IEnumerable<Item> ApplySorting(IEnumerable<Item> query, string orderBy, string orderDirection)
        {
            if (orderDirection.ToLower() == "asc")
            {
                switch (orderBy.ToLower())
                {
                    case "name":
                        query = query.OrderBy(item => item.Name);
                        break;
                    default:
                        query = query.OrderBy(item => item.Name);
                        break;
                }
            }
            else
            {
                switch (orderBy.ToLower())
                {
                    case "name":
                        query = query.OrderByDescending(item => item.Name);
                        break;
                    default:
                        query = query.OrderByDescending(item => item.Name);
                        break;
                }
            }

            return query;
        }


        public async Task<ItemResponseDTO> GetItem(Guid id)
        {
            try
            {
                var item = await _itemRepository.FindOneAsync(i =>
                    i.Id == id && i.IsActive == true && i.IsDeleted == false);
                if (item == null)
                    throw new Exception("Item no encontrado");
                return _mapper.Map<ItemResponseDTO>(item);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el item", ex);
            }
        }

        public async Task<ItemResponseDTO> CreateItem(ItemCreateDTO item)
        {
            try
            {
                var newItem = _mapper.Map<Item>(item);
                await _itemRepository.AddAsync(newItem);
                return _mapper.Map<ItemResponseDTO>(newItem);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el item", ex);
            }
        }

        public async Task<ItemResponseDTO> UpdateItem(Guid id, ItemCreateDTO item)
        {
            try
            {
                var itemToUpdate =
                    await _itemRepository.FindOneAsync(i => i.Id == id && i.IsActive == true && i.IsDeleted == false);
                if (itemToUpdate == null)
                    throw new Exception("Item no encontrado");
                itemToUpdate = _mapper.Map(item, itemToUpdate);
                await _itemRepository.UpdateAsync(itemToUpdate);
                return _mapper.Map<ItemResponseDTO>(itemToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el item", ex);
            }
        }

        public async Task<ItemResponseDTO> DeleteItem(Guid id)
        {
            try
            {
                var itemToDelete =
                    await _itemRepository.FindOneAsync(i => i.Id == id && i.IsActive == true && i.IsDeleted == false);
                if (itemToDelete == null)
                    throw new Exception("Item no encontrado");
                itemToDelete.IsActive = false;
                itemToDelete.IsDeleted = true;
                await _itemRepository.UpdateAsync(itemToDelete);
                return _mapper.Map<ItemResponseDTO>(itemToDelete);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el item", ex);
            }
        }
    }
}