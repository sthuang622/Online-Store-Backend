using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class CartMapper
{
    public static CartVo ToVo(this Cart Cart)
    {
        return new CartVo
        {
            Id = Cart.Id,
            UserId = Cart.UserId,
            CreatedAt = Cart.CreatedAt,
            UpdatedAt = Cart.UpdatedAt
        };
    }

    public static Cart ToDbObject(this CartVo CartVo)
    {
        return new Cart
        {
            Id = CartVo.Id,
            UserId = CartVo.UserId,
            CreatedAt = CartVo.CreatedAt,
            UpdatedAt = CartVo.UpdatedAt
        };
    }

    public static CartDto ToDto(this CartVo CartVo)
    {
        return new CartDto
        {
            Id = CartVo.Id,
            UserId = CartVo.UserId,
            CreatedAt = CartVo.CreatedAt,
            UpdatedAt = CartVo.UpdatedAt
        };
    }

    public static CartVo ToVo(this CartDto CartDto)
    {
        return new CartVo
        {
            Id = CartDto.Id,
            UserId = CartDto.UserId,
            CreatedAt = CartDto.CreatedAt,
            UpdatedAt = CartDto.UpdatedAt
        };
    }
}
