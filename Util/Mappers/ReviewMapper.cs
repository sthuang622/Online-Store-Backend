using Online_Store_Backend_WebAPI.DB.Data;
using Online_Store_Backend_WebAPI.Models.DTOs;
using Online_Store_Backend_WebAPI.Models.VOs;

namespace Online_Store_Backend_WebAPI.Util.Mappers;

public static class ReviewMapper
{
    public static ReviewVo ToVo(this Review Review)
    {
        return new ReviewVo
        {
            Id = Review.Id,
            UserId = Review.UserId,
            ProductId = Review.ProductId,
            Rating = Review.Rating,
            Body = Review.Body,
            PlaytimeMinutesAtReview = Review.PlaytimeMinutesAtReview,
            CreatedAt = Review.CreatedAt,
            UpdatedAt = Review.UpdatedAt
        };
    }

    public static Review ToDbObject(this ReviewVo ReviewVo)
    {
        return new Review
        {
            Id = ReviewVo.Id,
            UserId = ReviewVo.UserId,
            ProductId = ReviewVo.ProductId,
            Rating = ReviewVo.Rating,
            Body = ReviewVo.Body,
            PlaytimeMinutesAtReview = ReviewVo.PlaytimeMinutesAtReview,
            CreatedAt = ReviewVo.CreatedAt,
            UpdatedAt = ReviewVo.UpdatedAt
        };
    }

    public static ReviewDto ToDto(this ReviewVo ReviewVo)
    {
        return new ReviewDto
        {
            Id = ReviewVo.Id,
            UserId = ReviewVo.UserId,
            ProductId = ReviewVo.ProductId,
            Rating = ReviewVo.Rating,
            Body = ReviewVo.Body,
            PlaytimeMinutesAtReview = ReviewVo.PlaytimeMinutesAtReview,
            CreatedAt = ReviewVo.CreatedAt,
            UpdatedAt = ReviewVo.UpdatedAt
        };
    }

    public static ReviewVo ToVo(this ReviewDto ReviewDto)
    {
        return new ReviewVo
        {
            Id = ReviewDto.Id,
            UserId = ReviewDto.UserId,
            ProductId = ReviewDto.ProductId,
            Rating = ReviewDto.Rating,
            Body = ReviewDto.Body,
            PlaytimeMinutesAtReview = ReviewDto.PlaytimeMinutesAtReview,
            CreatedAt = ReviewDto.CreatedAt,
            UpdatedAt = ReviewDto.UpdatedAt
        };
    }
}
