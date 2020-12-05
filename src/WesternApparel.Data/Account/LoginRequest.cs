using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.Account
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Passwords must be between 2 and 24 characters long")]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }
    }
}