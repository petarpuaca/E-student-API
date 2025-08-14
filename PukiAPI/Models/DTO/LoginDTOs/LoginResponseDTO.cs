namespace PukiAPI.Models.DTO.LoginDTOs
{
    public class LoginResponseDTO
    {
        public string JwtToken { get; set; }
        public List<string> roles { get; set; }
    }
}
