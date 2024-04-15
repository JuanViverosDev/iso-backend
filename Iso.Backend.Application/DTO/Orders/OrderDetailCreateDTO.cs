using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class OrderDetailCreateDTO
{
    public Guid ItemId { get; set; }
    public Guid? DesignId { get; set; }
    public Guid OrderId { get; set; }
}
