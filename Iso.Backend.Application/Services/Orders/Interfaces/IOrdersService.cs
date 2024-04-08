// using Iso.Backend.Application.DTO.;

using Iso.Backend.Application.DTO.Contracts;

namespace Iso.Backend.Application.Services.Orders.Interfaces
{
	public interface IOrdersService
    {
	    public Task<IEnumerable<OrderResponseDTO>> GetOrders();
    }
}
