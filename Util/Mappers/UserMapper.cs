using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class UserMapper
{
    public static UserVo ToVo(this User User)
    {
        return new UserVo
        {
            Id = User.Id,
            Email = User.Email,
            Username = User.Username,
            PasswordHash = User.PasswordHash,
            Status = User.Status,
            CreatedAt = User.CreatedAt,
            UpdatedAt = User.UpdatedAt
        };
    }

    public static User ToDbObject(this UserVo UserVo)
    {
        return new User
        {
            Id = UserVo.Id,
            Email = UserVo.Email,
            Username = UserVo.Username,
            PasswordHash = UserVo.PasswordHash,
            Status = UserVo.Status,
            CreatedAt = UserVo.CreatedAt,
            UpdatedAt = UserVo.UpdatedAt
        };
    }

    public static UserDto ToDto(this UserVo UserVo)
    {
        return new UserDto
        {
            Id = UserVo.Id,
            Email = UserVo.Email,
            Username = UserVo.Username,
            PasswordHash = UserVo.PasswordHash,
            Status = UserVo.Status,
            CreatedAt = UserVo.CreatedAt,
            UpdatedAt = UserVo.UpdatedAt
        };
    }

    public static UserVo ToVo(this UserDto UserDto)
    {
        return new UserVo
        {
            Id = UserDto.Id,
            Email = UserDto.Email,
            Username = UserDto.Username,
            PasswordHash = UserDto.PasswordHash,
            Status = UserDto.Status,
            CreatedAt = UserDto.CreatedAt,
            UpdatedAt = UserDto.UpdatedAt
        };
    }
}
