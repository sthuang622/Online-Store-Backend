using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class ProductMapper
{
    public static ProductVo ToVo(this Product Product)
    {
        return new ProductVo
        {
            Id = Product.Id,
            Type = Product.Type,
            GameId = Product.GameId,
            Name = Product.Name,
            Slug = Product.Slug,
            CreatedAt = Product.CreatedAt,
            UpdatedAt = Product.UpdatedAt
        };
    }

    public static Product ToDbObject(this ProductVo ProductVo)
    {
        return new Product
        {
            Id = ProductVo.Id,
            Type = ProductVo.Type,
            GameId = ProductVo.GameId,
            Name = ProductVo.Name,
            Slug = ProductVo.Slug,
            CreatedAt = ProductVo.CreatedAt,
            UpdatedAt = ProductVo.UpdatedAt
        };
    }

    public static ProductDto ToDto(this ProductVo ProductVo)
    {
        return new ProductDto
        {
            Id = ProductVo.Id,
            Type = ProductVo.Type,
            GameId = ProductVo.GameId,
            Name = ProductVo.Name,
            Slug = ProductVo.Slug,
            CreatedAt = ProductVo.CreatedAt,
            UpdatedAt = ProductVo.UpdatedAt
        };
    }

    public static ProductVo ToVo(this ProductDto ProductDto)
    {
        return new ProductVo
        {
            Id = ProductDto.Id,
            Type = ProductDto.Type,
            GameId = ProductDto.GameId,
            Name = ProductDto.Name,
            Slug = ProductDto.Slug,
            CreatedAt = ProductDto.CreatedAt,
            UpdatedAt = ProductDto.UpdatedAt
        };
    }
}
