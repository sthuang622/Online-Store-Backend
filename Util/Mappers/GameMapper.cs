using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class GameMapper
{
    public static GameVo ToVo(this Game Game)
    {
        return new GameVo
        {
            Id = Game.Id,
            PublisherId = Game.PublisherId,
            Name = Game.Name,
            Slug = Game.Slug,
            ShortDescription = Game.ShortDescription,
            LongDescription = Game.LongDescription,
            Status = Game.Status,
            ReleaseDate = Game.ReleaseDate,
            CreatedAt = Game.CreatedAt,
            UpdatedAt = Game.UpdatedAt
        };
    }

    public static Game ToDbObject(this GameVo GameVo)
    {
        return new Game
        {
            Id = GameVo.Id,
            PublisherId = GameVo.PublisherId,
            Name = GameVo.Name,
            Slug = GameVo.Slug,
            ShortDescription = GameVo.ShortDescription,
            LongDescription = GameVo.LongDescription,
            Status = GameVo.Status,
            ReleaseDate = GameVo.ReleaseDate,
            CreatedAt = GameVo.CreatedAt,
            UpdatedAt = GameVo.UpdatedAt
        };
    }

    public static GameDto ToDto(this GameVo GameVo)
    {
        return new GameDto
        {
            Id = GameVo.Id,
            PublisherId = GameVo.PublisherId,
            Name = GameVo.Name,
            Slug = GameVo.Slug,
            ShortDescription = GameVo.ShortDescription,
            LongDescription = GameVo.LongDescription,
            Status = GameVo.Status,
            ReleaseDate = GameVo.ReleaseDate,
            CreatedAt = GameVo.CreatedAt,
            UpdatedAt = GameVo.UpdatedAt
        };
    }

    public static GameVo ToVo(this GameDto GameDto)
    {
        return new GameVo
        {
            Id = GameDto.Id,
            PublisherId = GameDto.PublisherId,
            Name = GameDto.Name,
            Slug = GameDto.Slug,
            ShortDescription = GameDto.ShortDescription,
            LongDescription = GameDto.LongDescription,
            Status = GameDto.Status,
            ReleaseDate = GameDto.ReleaseDate,
            CreatedAt = GameDto.CreatedAt,
            UpdatedAt = GameDto.UpdatedAt
        };
    }
}
