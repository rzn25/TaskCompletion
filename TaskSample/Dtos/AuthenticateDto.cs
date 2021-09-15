using System.ComponentModel.DataAnnotations;

namespace TaskSample.Dtos
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}