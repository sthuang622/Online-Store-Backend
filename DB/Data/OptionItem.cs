namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class OptionItem
{
    public string CodeId { get; set; } = string.Empty;

    public string CodeKind { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}
