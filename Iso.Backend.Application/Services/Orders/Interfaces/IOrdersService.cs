// using Iso.Backend.Application.DTO.;

using Iso.Backend.Application.DTO.Items;

namespace Iso.Backend.Application.Services.Orders.Interfaces
{
	public interface IOrdersService
    {
	    public Task<IEnumerable<OrderResponseDTO>> GetOrders();
    }
}
