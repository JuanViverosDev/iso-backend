namespace Iso.Backend.Domain.Entities.JsonModels;

public class ItemDetails
{
    public string[]? Sizes { get; set; }
    public string[]? Colors { get; set; }
    public string MainImage { get; set; } = string.Empty;
    public string[]? Images { get; set; }
}