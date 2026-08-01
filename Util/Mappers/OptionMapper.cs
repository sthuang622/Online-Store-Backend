using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class OptionMapper
{
    public static OptionVo ToVo(this OptionItem optionItem)
    {
        return new OptionVo
        {
            CodeId = optionItem.CodeId,
            CodeKind = optionItem.CodeKind,
            Name = optionItem.Name,
            Description = optionItem.Description
        };
    }

    public static OptionKindDto ToDto(this OptionVo optionVo)
    {
        return new OptionKindDto
        {
            CodeKind = optionVo.CodeKind,
            Name = optionVo.Name,
            Description = optionVo.Description
        };
    }
}
