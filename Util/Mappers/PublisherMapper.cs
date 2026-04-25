using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class PublisherMapper
{
    public static PublisherVo ToVo(this Publisher Publisher)
    {
        return new PublisherVo
        {
            Id = Publisher.Id,
            Name = Publisher.Name,
            Slug = Publisher.Slug,
            Website = Publisher.Website,
            LogoUrl = Publisher.LogoUrl,
            Description = Publisher.Description,
            CreatedAt = Publisher.CreatedAt,
            UpdatedAt = Publisher.UpdatedAt
        };
    }

    public static Publisher ToDbObject(this PublisherVo PublisherVo)
    {
        return new Publisher
        {
            Id = PublisherVo.Id,
            Name = PublisherVo.Name,
            Slug = PublisherVo.Slug,
            Website = PublisherVo.Website,
            LogoUrl = PublisherVo.LogoUrl,
            Description = PublisherVo.Description,
            CreatedAt = PublisherVo.CreatedAt,
            UpdatedAt = PublisherVo.UpdatedAt
        };
    }

    public static PublisherDto ToDto(this PublisherVo PublisherVo)
    {
        return new PublisherDto
        {
            Id = PublisherVo.Id,
            Name = PublisherVo.Name,
            Slug = PublisherVo.Slug,
            Website = PublisherVo.Website,
            LogoUrl = PublisherVo.LogoUrl,
            Description = PublisherVo.Description,
            CreatedAt = PublisherVo.CreatedAt,
            UpdatedAt = PublisherVo.UpdatedAt
        };
    }

    public static PublisherVo ToVo(this PublisherDto PublisherDto)
    {
        return new PublisherVo
        {
            Id = PublisherDto.Id,
            Name = PublisherDto.Name,
            Slug = PublisherDto.Slug,
            Website = PublisherDto.Website,
            LogoUrl = PublisherDto.LogoUrl,
            Description = PublisherDto.Description,
            CreatedAt = PublisherDto.CreatedAt,
            UpdatedAt = PublisherDto.UpdatedAt
        };
    }
}
