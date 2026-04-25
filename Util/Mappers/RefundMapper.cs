using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class RefundMapper
{
    public static RefundVo ToVo(this Refund Refund)
    {
        return new RefundVo
        {
            Id = Refund.Id,
            PaymentId = Refund.PaymentId,
            AmountMinor = Refund.AmountMinor,
            Reason = Refund.Reason,
            CreatedAt = Refund.CreatedAt
        };
    }

    public static Refund ToDbObject(this RefundVo RefundVo)
    {
        return new Refund
        {
            Id = RefundVo.Id,
            PaymentId = RefundVo.PaymentId,
            AmountMinor = RefundVo.AmountMinor,
            Reason = RefundVo.Reason,
            CreatedAt = RefundVo.CreatedAt
        };
    }

    public static RefundDto ToDto(this RefundVo RefundVo)
    {
        return new RefundDto
        {
            Id = RefundVo.Id,
            PaymentId = RefundVo.PaymentId,
            AmountMinor = RefundVo.AmountMinor,
            Reason = RefundVo.Reason,
            CreatedAt = RefundVo.CreatedAt
        };
    }

    public static RefundVo ToVo(this RefundDto RefundDto)
    {
        return new RefundVo
        {
            Id = RefundDto.Id,
            PaymentId = RefundDto.PaymentId,
            AmountMinor = RefundDto.AmountMinor,
            Reason = RefundDto.Reason,
            CreatedAt = RefundDto.CreatedAt
        };
    }
}
