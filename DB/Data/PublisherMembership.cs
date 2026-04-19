using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class PublisherMembership
{
    public ulong PublisherId { get; set; }

    public ulong UserId { get; set; }

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
