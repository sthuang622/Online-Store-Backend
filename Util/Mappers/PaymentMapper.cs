using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class PaymentMapper
{
    public static PaymentVo ToVo(this Payment Payment)
    {
        return new PaymentVo
        {
            Id = Payment.Id,
            OrderId = Payment.OrderId,
            Provider = Payment.Provider,
            ProviderPaymentId = Payment.ProviderPaymentId,
            Status = Payment.Status,
            AmountMinor = Payment.AmountMinor,
            CurrencyCode = Payment.CurrencyCode,
            CreatedAt = Payment.CreatedAt,
            UpdatedAt = Payment.UpdatedAt
        };
    }

    public static Payment ToDbObject(this PaymentVo PaymentVo)
    {
        return new Payment
        {
            Id = PaymentVo.Id,
            OrderId = PaymentVo.OrderId,
            Provider = PaymentVo.Provider,
            ProviderPaymentId = PaymentVo.ProviderPaymentId,
            Status = PaymentVo.Status,
            AmountMinor = PaymentVo.AmountMinor,
            CurrencyCode = PaymentVo.CurrencyCode,
            CreatedAt = PaymentVo.CreatedAt,
            UpdatedAt = PaymentVo.UpdatedAt
        };
    }

    public static PaymentDto ToDto(this PaymentVo PaymentVo)
    {
        return new PaymentDto
        {
            Id = PaymentVo.Id,
            OrderId = PaymentVo.OrderId,
            Provider = PaymentVo.Provider,
            ProviderPaymentId = PaymentVo.ProviderPaymentId,
            Status = PaymentVo.Status,
            AmountMinor = PaymentVo.AmountMinor,
            CurrencyCode = PaymentVo.CurrencyCode,
            CreatedAt = PaymentVo.CreatedAt,
            UpdatedAt = PaymentVo.UpdatedAt
        };
    }

    public static PaymentVo ToVo(this PaymentDto PaymentDto)
    {
        return new PaymentVo
        {
            Id = PaymentDto.Id,
            OrderId = PaymentDto.OrderId,
            Provider = PaymentDto.Provider,
            ProviderPaymentId = PaymentDto.ProviderPaymentId,
            Status = PaymentDto.Status,
            AmountMinor = PaymentDto.AmountMinor,
            CurrencyCode = PaymentDto.CurrencyCode,
            CreatedAt = PaymentDto.CreatedAt,
            UpdatedAt = PaymentDto.UpdatedAt
        };
    }
}
