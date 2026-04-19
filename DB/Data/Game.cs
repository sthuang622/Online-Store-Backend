using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class Game
{
    public ulong Id { get; set; }

    public ulong PublisherId { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? ShortDescription { get; set; }

    public string? LongDescription { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? ReleaseDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<GameMedium> GameMedia { get; set; } = new List<GameMedium>();

    public virtual ICollection<GamePrice> GamePrices { get; set; } = new List<GamePrice>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Publisher Publisher { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
