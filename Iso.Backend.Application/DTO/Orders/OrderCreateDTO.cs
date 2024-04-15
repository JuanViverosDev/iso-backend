using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class OrderCreateDTO
{
    public Guid UserId { get; set; }
    public string State { get; set; } = string.Empty;
    public List<OrderDetailCreateDTO> OrderDetails { get; set; }
}