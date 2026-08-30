namespace GameTournamentApplication.Services.AuthServices.DTOs
{
    public record LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
