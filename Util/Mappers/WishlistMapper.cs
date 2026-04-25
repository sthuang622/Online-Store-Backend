using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class WishlistMapper
{
    public static WishlistVo ToVo(this Wishlist Wishlist)
    {
        return new WishlistVo
        {
            UserId = Wishlist.UserId,
            ProductId = Wishlist.ProductId,
            CreatedAt = Wishlist.CreatedAt
        };
    }

    public static Wishlist ToDbObject(this WishlistVo WishlistVo)
    {
        return new Wishlist
        {
            UserId = WishlistVo.UserId,
            ProductId = WishlistVo.ProductId,
            CreatedAt = WishlistVo.CreatedAt
        };
    }

    public static WishlistDto ToDto(this WishlistVo WishlistVo)
    {
        return new WishlistDto
        {
            UserId = WishlistVo.UserId,
            ProductId = WishlistVo.ProductId,
            CreatedAt = WishlistVo.CreatedAt
        };
    }

    public static WishlistVo ToVo(this WishlistDto WishlistDto)
    {
        return new WishlistVo
        {
            UserId = WishlistDto.UserId,
            ProductId = WishlistDto.ProductId,
            CreatedAt = WishlistDto.CreatedAt
        };
    }
}
