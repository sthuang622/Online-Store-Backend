namespace Online_Store_Backend_WebAPI.Models.Response {
    public record LoginResponseDto {
        public BasicResponseDto response { get; init; } = null!;
        public string[] roles { get; init; } = null!;
    }
}
