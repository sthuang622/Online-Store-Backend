using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class GameMedium
{
    public ulong Id { get; set; }

    public ulong GameId { get; set; }

    public string Type { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int SortOrder { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Game Game { get; set; } = null!;
}
