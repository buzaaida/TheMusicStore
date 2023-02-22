using System.ComponentModel.DataAnnotations;

namespace TheMusicStore
{
    public class SignIn
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
