using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class ItemResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; } = 0;
    public int Availability { get; set; } = 0;
    public Guid CategoryId { get; set; } = Guid.Empty;
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public List<CommentItem> Comments { get; set; } = new List<CommentItem>();
}