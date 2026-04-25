using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class OrderMapper
{
    public static OrderVo ToVo(this Order Order)
    {
        return new OrderVo
        {
            Id = Order.Id,
            UserId = Order.UserId,
            Status = Order.Status,
            RegionCode = Order.RegionCode,
            CurrencyCode = Order.CurrencyCode,
            SubtotalMinor = Order.SubtotalMinor,
            TaxMinor = Order.TaxMinor,
            TotalMinor = Order.TotalMinor,
            CreatedAt = Order.CreatedAt,
            PaidAt = Order.PaidAt
        };
    }

    public static Order ToDbObject(this OrderVo OrderVo)
    {
        return new Order
        {
            Id = OrderVo.Id,
            UserId = OrderVo.UserId,
            Status = OrderVo.Status,
            RegionCode = OrderVo.RegionCode,
            CurrencyCode = OrderVo.CurrencyCode,
            SubtotalMinor = OrderVo.SubtotalMinor,
            TaxMinor = OrderVo.TaxMinor,
            TotalMinor = OrderVo.TotalMinor,
            CreatedAt = OrderVo.CreatedAt,
            PaidAt = OrderVo.PaidAt
        };
    }

    public static OrderDto ToDto(this OrderVo OrderVo)
    {
        return new OrderDto
        {
            Id = OrderVo.Id,
            UserId = OrderVo.UserId,
            Status = OrderVo.Status,
            RegionCode = OrderVo.RegionCode,
            CurrencyCode = OrderVo.CurrencyCode,
            SubtotalMinor = OrderVo.SubtotalMinor,
            TaxMinor = OrderVo.TaxMinor,
            TotalMinor = OrderVo.TotalMinor,
            CreatedAt = OrderVo.CreatedAt,
            PaidAt = OrderVo.PaidAt
        };
    }

    public static OrderVo ToVo(this OrderDto OrderDto)
    {
        return new OrderVo
        {
            Id = OrderDto.Id,
            UserId = OrderDto.UserId,
            Status = OrderDto.Status,
            RegionCode = OrderDto.RegionCode,
            CurrencyCode = OrderDto.CurrencyCode,
            SubtotalMinor = OrderDto.SubtotalMinor,
            TaxMinor = OrderDto.TaxMinor,
            TotalMinor = OrderDto.TotalMinor,
            CreatedAt = OrderDto.CreatedAt,
            PaidAt = OrderDto.PaidAt
        };
    }
}
