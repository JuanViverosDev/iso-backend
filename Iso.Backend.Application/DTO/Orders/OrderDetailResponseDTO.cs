using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.JsonModels;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class OrderDetailResponseDTO
{
    public Guid Id { get; set; }
    public Guid ItemId { get; set; }
    public Guid? DesignId { get; set; }
    public Guid OrderId { get; set; }
    public OrderDetailsMetadata? Details { get; set; }
}
