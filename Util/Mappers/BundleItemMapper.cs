using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class BundleItemMapper
{
    public static BundleItemVo ToVo(this BundleItem BundleItem)
    {
        return new BundleItemVo
        {
            BundleProductId = BundleItem.BundleProductId,
            ItemProductId = BundleItem.ItemProductId,
            Quantity = BundleItem.Quantity
        };
    }

    public static BundleItem ToDbObject(this BundleItemVo BundleItemVo)
    {
        return new BundleItem
        {
            BundleProductId = BundleItemVo.BundleProductId,
            ItemProductId = BundleItemVo.ItemProductId,
            Quantity = BundleItemVo.Quantity
        };
    }

    public static BundleItemDto ToDto(this BundleItemVo BundleItemVo)
    {
        return new BundleItemDto
        {
            BundleProductId = BundleItemVo.BundleProductId,
            ItemProductId = BundleItemVo.ItemProductId,
            Quantity = BundleItemVo.Quantity
        };
    }

    public static BundleItemVo ToVo(this BundleItemDto BundleItemDto)
    {
        return new BundleItemVo
        {
            BundleProductId = BundleItemDto.BundleProductId,
            ItemProductId = BundleItemDto.ItemProductId,
            Quantity = BundleItemDto.Quantity
        };
    }
}
