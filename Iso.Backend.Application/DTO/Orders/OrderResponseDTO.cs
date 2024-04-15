using System.ComponentModel.DataAnnotations.Schema;
using Iso.Backend.Domain.Entities.JsonModels;
using Iso.Backend.Domain.Entities.Orders;
namespace Iso.Backend.Application.DTO.Items;

public class OrderResponseDTO
{
    public Guid Id { get; set; }
    public string State { get; set; } = string.Empty;
    public List<OrderDetail> OrderDetails { get; set; }
    public OrderDetails? Details { get; set; }
}