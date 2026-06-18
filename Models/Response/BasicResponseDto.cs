namespace Online_Store_Backend_WebAPI.Models.Response {
    public record class BasicResponseDto {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }
}
