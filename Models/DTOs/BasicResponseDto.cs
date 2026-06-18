namespace Online_Store_Backend_WebAPI.Models.DTOs {
    public sealed class BasicResponseDto {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
