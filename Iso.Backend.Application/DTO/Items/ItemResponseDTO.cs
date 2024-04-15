using Iso.Backend.Domain.Entities.JsonModels;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class ItemResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; } = 0;
    public int Availability { get; set; } = 0;
    public Guid CategoryId { get; set; } = Guid.Empty;
    public ItemDetails? Details { get; set; }
    public List<CommentItem> Comments { get; set; } = new List<CommentItem>();
}