using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class GameMapper
{
    public static GameVo ToVo(this Game game)
    {
        return new GameVo
        {
            Id = game.Id,
            PublisherId = game.PublisherId,
            Name = game.Name,
            Slug = game.Slug,
            ShortDescription = game.ShortDescription,
            LongDescription = game.LongDescription,
            Status = game.Status,
            ReleaseDate = game.ReleaseDate
        };
    }

    public static Game ToDbObject(this GameVo gameVo)
    {
        return new Game
        {
            Id = gameVo.Id,
            PublisherId = gameVo.PublisherId,
            Name = gameVo.Name,
            Slug = gameVo.Slug,
            ShortDescription = gameVo.ShortDescription,
            LongDescription = gameVo.LongDescription,
            Status = gameVo.Status,
            ReleaseDate = gameVo.ReleaseDate
        };
    }

    public static GameDto ToDto(this GameVo gameVo)
    {
        return new GameDto
        {
            Id = gameVo.Id,
            PublisherId = gameVo.PublisherId,
            Name = gameVo.Name,
            Slug = gameVo.Slug,
            ShortDescription = gameVo.ShortDescription,
            LongDescription = gameVo.LongDescription,
            Status = gameVo.Status,
            ReleaseDate = gameVo.ReleaseDate
        };
    }

    public static GameVo ToVo(this GameDto gameDto)
    {
        return new GameVo
        {
            Id = gameDto.Id,
            PublisherId = gameDto.PublisherId,
            Name = gameDto.Name,
            Slug = gameDto.Slug,
            ShortDescription = gameDto.ShortDescription,
            LongDescription = gameDto.LongDescription,
            Status = gameDto.Status,
            ReleaseDate = gameDto.ReleaseDate
        };
    }
}
