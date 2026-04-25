using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class TagMapper
{
    public static TagVo ToVo(this Tag Tag)
    {
        return new TagVo
        {
            Id = Tag.Id,
            Name = Tag.Name,
            Slug = Tag.Slug
        };
    }

    public static Tag ToDbObject(this TagVo TagVo)
    {
        return new Tag
        {
            Id = TagVo.Id,
            Name = TagVo.Name,
            Slug = TagVo.Slug
        };
    }

    public static TagDto ToDto(this TagVo TagVo)
    {
        return new TagDto
        {
            Id = TagVo.Id,
            Name = TagVo.Name,
            Slug = TagVo.Slug
        };
    }

    public static TagVo ToVo(this TagDto TagDto)
    {
        return new TagVo
        {
            Id = TagDto.Id,
            Name = TagDto.Name,
            Slug = TagDto.Slug
        };
    }
}
