namespace Iso.Backend.Application.DTO.Items;

public class OrderCreateDTO
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public Guid DesignId { get; set; }
    public string State { get; set; } = string.Empty;
}