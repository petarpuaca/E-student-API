using System.ComponentModel.DataAnnotations;

namespace PukiAPI.Models.DTO.LoginDTOs
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
