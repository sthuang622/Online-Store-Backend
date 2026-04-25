using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class CartItemMapper
{
    public static CartItemVo ToVo(this CartItem CartItem)
    {
        return new CartItemVo
        {
            CartId = CartItem.CartId,
            ProductId = CartItem.ProductId,
            Quantity = CartItem.Quantity,
            AddedAt = CartItem.AddedAt
        };
    }

    public static CartItem ToDbObject(this CartItemVo CartItemVo)
    {
        return new CartItem
        {
            CartId = CartItemVo.CartId,
            ProductId = CartItemVo.ProductId,
            Quantity = CartItemVo.Quantity,
            AddedAt = CartItemVo.AddedAt
        };
    }

    public static CartItemDto ToDto(this CartItemVo CartItemVo)
    {
        return new CartItemDto
        {
            CartId = CartItemVo.CartId,
            ProductId = CartItemVo.ProductId,
            Quantity = CartItemVo.Quantity,
            AddedAt = CartItemVo.AddedAt
        };
    }

    public static CartItemVo ToVo(this CartItemDto CartItemDto)
    {
        return new CartItemVo
        {
            CartId = CartItemDto.CartId,
            ProductId = CartItemDto.ProductId,
            Quantity = CartItemDto.Quantity,
            AddedAt = CartItemDto.AddedAt
        };
    }
}
