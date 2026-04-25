using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class GameMediumMapper
{
    public static GameMediumVo ToVo(this GameMedium GameMedium)
    {
        return new GameMediumVo
        {
            Id = GameMedium.Id,
            GameId = GameMedium.GameId,
            Type = GameMedium.Type,
            Url = GameMedium.Url,
            SortOrder = GameMedium.SortOrder,
            CreatedAt = GameMedium.CreatedAt
        };
    }

    public static GameMedium ToDbObject(this GameMediumVo GameMediumVo)
    {
        return new GameMedium
        {
            Id = GameMediumVo.Id,
            GameId = GameMediumVo.GameId,
            Type = GameMediumVo.Type,
            Url = GameMediumVo.Url,
            SortOrder = GameMediumVo.SortOrder,
            CreatedAt = GameMediumVo.CreatedAt
        };
    }

    public static GameMediumDto ToDto(this GameMediumVo GameMediumVo)
    {
        return new GameMediumDto
        {
            Id = GameMediumVo.Id,
            GameId = GameMediumVo.GameId,
            Type = GameMediumVo.Type,
            Url = GameMediumVo.Url,
            SortOrder = GameMediumVo.SortOrder,
            CreatedAt = GameMediumVo.CreatedAt
        };
    }

    public static GameMediumVo ToVo(this GameMediumDto GameMediumDto)
    {
        return new GameMediumVo
        {
            Id = GameMediumDto.Id,
            GameId = GameMediumDto.GameId,
            Type = GameMediumDto.Type,
            Url = GameMediumDto.Url,
            SortOrder = GameMediumDto.SortOrder,
            CreatedAt = GameMediumDto.CreatedAt
        };
    }
}
