using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class Product
{
    public ulong Id { get; set; }

    public string Type { get; set; } = null!;

    public ulong? GameId { get; set; }

    public string Name { get; set; } = null!;

    public string? Slug { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<BundleItem> BundleItemBundleProducts { get; set; } = new List<BundleItem>();

    public virtual ICollection<BundleItem> BundleItemItemProducts { get; set; } = new List<BundleItem>();

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Game? Game { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UserLibrary> UserLibraries { get; set; } = new List<UserLibrary>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
