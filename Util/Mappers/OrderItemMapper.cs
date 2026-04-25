using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class OrderItemMapper
{
    public static OrderItemVo ToVo(this OrderItem OrderItem)
    {
        return new OrderItemVo
        {
            Id = OrderItem.Id,
            OrderId = OrderItem.OrderId,
            ProductId = OrderItem.ProductId,
            Quantity = OrderItem.Quantity,
            UnitPriceMinor = OrderItem.UnitPriceMinor,
            DiscountMinor = OrderItem.DiscountMinor,
            FinalPriceMinor = OrderItem.FinalPriceMinor,
            CreatedAt = OrderItem.CreatedAt
        };
    }

    public static OrderItem ToDbObject(this OrderItemVo OrderItemVo)
    {
        return new OrderItem
        {
            Id = OrderItemVo.Id,
            OrderId = OrderItemVo.OrderId,
            ProductId = OrderItemVo.ProductId,
            Quantity = OrderItemVo.Quantity,
            UnitPriceMinor = OrderItemVo.UnitPriceMinor,
            DiscountMinor = OrderItemVo.DiscountMinor,
            FinalPriceMinor = OrderItemVo.FinalPriceMinor,
            CreatedAt = OrderItemVo.CreatedAt
        };
    }

    public static OrderItemDto ToDto(this OrderItemVo OrderItemVo)
    {
        return new OrderItemDto
        {
            Id = OrderItemVo.Id,
            OrderId = OrderItemVo.OrderId,
            ProductId = OrderItemVo.ProductId,
            Quantity = OrderItemVo.Quantity,
            UnitPriceMinor = OrderItemVo.UnitPriceMinor,
            DiscountMinor = OrderItemVo.DiscountMinor,
            FinalPriceMinor = OrderItemVo.FinalPriceMinor,
            CreatedAt = OrderItemVo.CreatedAt
        };
    }

    public static OrderItemVo ToVo(this OrderItemDto OrderItemDto)
    {
        return new OrderItemVo
        {
            Id = OrderItemDto.Id,
            OrderId = OrderItemDto.OrderId,
            ProductId = OrderItemDto.ProductId,
            Quantity = OrderItemDto.Quantity,
            UnitPriceMinor = OrderItemDto.UnitPriceMinor,
            DiscountMinor = OrderItemDto.DiscountMinor,
            FinalPriceMinor = OrderItemDto.FinalPriceMinor,
            CreatedAt = OrderItemDto.CreatedAt
        };
    }
}
