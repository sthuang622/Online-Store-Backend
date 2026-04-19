using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class GamePrice
{
    public ulong Id { get; set; }

    public ulong GameId { get; set; }

    public string RegionCode { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public long PriceMinor { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Game Game { get; set; } = null!;
}
