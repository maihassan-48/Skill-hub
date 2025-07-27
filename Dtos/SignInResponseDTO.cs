namespace Skill_Hub.Dtos
{
    public class SignInResponseDTO
    {
        public required string Token { get; set; }
        public required DateTime Expiration { get; set; }
        public required int UserId { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
    }
}
