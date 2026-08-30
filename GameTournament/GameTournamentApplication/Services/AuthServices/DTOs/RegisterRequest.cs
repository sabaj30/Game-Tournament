namespace GameTournamentApplication.Services.AuthServices.DTOs
{
    public record RegisterRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
