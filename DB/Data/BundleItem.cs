using System;
using System.Collections.Generic;

namespace Online_Store_Backend_WebAPI.DB.Data;

public partial class BundleItem
{
    public ulong BundleProductId { get; set; }

    public ulong ItemProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product BundleProduct { get; set; } = null!;

    public virtual Product ItemProduct { get; set; } = null!;
}
