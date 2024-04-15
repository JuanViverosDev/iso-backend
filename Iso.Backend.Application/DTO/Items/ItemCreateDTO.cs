using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class ItemCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; } = 0;
    public int Availability { get; set; } = 0;
    public Guid CategoryId { get; set; }
}