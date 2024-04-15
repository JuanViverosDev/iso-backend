using AutoMapper;
using Iso.Backend.Application.DTO.Items;
using Iso.Backend.Application.Services.Orders.Interfaces;

namespace Iso.Backend.Application.Services.Orders.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IMapper _mapper;

        public OrdersService(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<OrderResponseDTO>> GetOrders()
        {
            // var result = await _orderRepository.FindAsync(w => w.IsActive == true && w.IsDeleted == false);
            // var mapped = _mapper.Map<IEnumerable<OrderResponseDTO>>(result);
            // return mapped;
            return new List<OrderResponseDTO>
            {
                new OrderResponseDTO
                {
                    Id = Guid.NewGuid()
                }
            };
        }
    }
}