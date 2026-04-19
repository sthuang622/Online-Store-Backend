using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class Review
{
    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public ulong ProductId { get; set; }

    public string Rating { get; set; } = null!;

    public string? Body { get; set; }

    public int? PlaytimeMinutesAtReview { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
