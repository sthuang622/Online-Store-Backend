using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class GamePriceMapper
{
    public static GamePriceVo ToVo(this GamePrice GamePrice)
    {
        return new GamePriceVo
        {
            Id = GamePrice.Id,
            GameId = GamePrice.GameId,
            RegionCode = GamePrice.RegionCode,
            CurrencyCode = GamePrice.CurrencyCode,
            PriceMinor = GamePrice.PriceMinor,
            CreatedAt = GamePrice.CreatedAt,
            UpdatedAt = GamePrice.UpdatedAt
        };
    }

    public static GamePrice ToDbObject(this GamePriceVo GamePriceVo)
    {
        return new GamePrice
        {
            Id = GamePriceVo.Id,
            GameId = GamePriceVo.GameId,
            RegionCode = GamePriceVo.RegionCode,
            CurrencyCode = GamePriceVo.CurrencyCode,
            PriceMinor = GamePriceVo.PriceMinor,
            CreatedAt = GamePriceVo.CreatedAt,
            UpdatedAt = GamePriceVo.UpdatedAt
        };
    }

    public static GamePriceDto ToDto(this GamePriceVo GamePriceVo)
    {
        return new GamePriceDto
        {
            Id = GamePriceVo.Id,
            GameId = GamePriceVo.GameId,
            RegionCode = GamePriceVo.RegionCode,
            CurrencyCode = GamePriceVo.CurrencyCode,
            PriceMinor = GamePriceVo.PriceMinor,
            CreatedAt = GamePriceVo.CreatedAt,
            UpdatedAt = GamePriceVo.UpdatedAt
        };
    }

    public static GamePriceVo ToVo(this GamePriceDto GamePriceDto)
    {
        return new GamePriceVo
        {
            Id = GamePriceDto.Id,
            GameId = GamePriceDto.GameId,
            RegionCode = GamePriceDto.RegionCode,
            CurrencyCode = GamePriceDto.CurrencyCode,
            PriceMinor = GamePriceDto.PriceMinor,
            CreatedAt = GamePriceDto.CreatedAt,
            UpdatedAt = GamePriceDto.UpdatedAt
        };
    }
}
