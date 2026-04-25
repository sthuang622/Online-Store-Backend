using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class UserLibraryMapper
{
    public static UserLibraryVo ToVo(this UserLibrary UserLibrary)
    {
        return new UserLibraryVo
        {
            Id = UserLibrary.Id,
            UserId = UserLibrary.UserId,
            ProductId = UserLibrary.ProductId,
            Source = UserLibrary.Source,
            OrderId = UserLibrary.OrderId,
            GrantedAt = UserLibrary.GrantedAt
        };
    }

    public static UserLibrary ToDbObject(this UserLibraryVo UserLibraryVo)
    {
        return new UserLibrary
        {
            Id = UserLibraryVo.Id,
            UserId = UserLibraryVo.UserId,
            ProductId = UserLibraryVo.ProductId,
            Source = UserLibraryVo.Source,
            OrderId = UserLibraryVo.OrderId,
            GrantedAt = UserLibraryVo.GrantedAt
        };
    }

    public static UserLibraryDto ToDto(this UserLibraryVo UserLibraryVo)
    {
        return new UserLibraryDto
        {
            Id = UserLibraryVo.Id,
            UserId = UserLibraryVo.UserId,
            ProductId = UserLibraryVo.ProductId,
            Source = UserLibraryVo.Source,
            OrderId = UserLibraryVo.OrderId,
            GrantedAt = UserLibraryVo.GrantedAt
        };
    }

    public static UserLibraryVo ToVo(this UserLibraryDto UserLibraryDto)
    {
        return new UserLibraryVo
        {
            Id = UserLibraryDto.Id,
            UserId = UserLibraryDto.UserId,
            ProductId = UserLibraryDto.ProductId,
            Source = UserLibraryDto.Source,
            OrderId = UserLibraryDto.OrderId,
            GrantedAt = UserLibraryDto.GrantedAt
        };
    }
}
