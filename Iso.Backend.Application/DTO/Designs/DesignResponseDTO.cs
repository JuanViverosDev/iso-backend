using Iso.Backend.Domain.Entities.JsonModels;
using Iso.Backend.Domain.Entities.Orders;

namespace Iso.Backend.Application.DTO.Items;

public class DesignResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string MainImage { get; set; } = string.Empty;
}