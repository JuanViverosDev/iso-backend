// using Iso.Backend.Application.DTO.;

using Iso.Backend.Application.DTO.Items;

namespace Iso.Backend.Application.Services.Orders.Interfaces
{
    public interface IOrdersService
    {
        Task<OrderResponseDTO> CreateOrder(OrderCreateDTO orderCreateDTO);
        Task<OrderResponseDTO> GetOrder(Guid orderId);
        Task<List<OrderResponseDTO>> GetOrders();
        Task<OrderResponseDTO> UpdateOrder(Guid orderId, OrderCreateDTO orderCreateDTO);
        Task<OrderResponseDTO> DeleteOrder(Guid orderId);
        Task<OrderResponseDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailCreateDTO);
    }
}