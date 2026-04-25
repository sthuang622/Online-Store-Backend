using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class PublisherMembershipMapper
{
    public static PublisherMembershipVo ToVo(this PublisherMembership PublisherMembership)
    {
        return new PublisherMembershipVo
        {
            PublisherId = PublisherMembership.PublisherId,
            UserId = PublisherMembership.UserId,
            Role = PublisherMembership.Role,
            CreatedAt = PublisherMembership.CreatedAt
        };
    }

    public static PublisherMembership ToDbObject(this PublisherMembershipVo PublisherMembershipVo)
    {
        return new PublisherMembership
        {
            PublisherId = PublisherMembershipVo.PublisherId,
            UserId = PublisherMembershipVo.UserId,
            Role = PublisherMembershipVo.Role,
            CreatedAt = PublisherMembershipVo.CreatedAt
        };
    }

    public static PublisherMembershipDto ToDto(this PublisherMembershipVo PublisherMembershipVo)
    {
        return new PublisherMembershipDto
        {
            PublisherId = PublisherMembershipVo.PublisherId,
            UserId = PublisherMembershipVo.UserId,
            Role = PublisherMembershipVo.Role,
            CreatedAt = PublisherMembershipVo.CreatedAt
        };
    }

    public static PublisherMembershipVo ToVo(this PublisherMembershipDto PublisherMembershipDto)
    {
        return new PublisherMembershipVo
        {
            PublisherId = PublisherMembershipDto.PublisherId,
            UserId = PublisherMembershipDto.UserId,
            Role = PublisherMembershipDto.Role,
            CreatedAt = PublisherMembershipDto.CreatedAt
        };
    }
}
