using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class UserLibrary
{
    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public ulong ProductId { get; set; }

    public string Source { get; set; } = null!;

    public ulong? OrderId { get; set; }

    public DateTime GrantedAt { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
