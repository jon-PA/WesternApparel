using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.Account
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public bool RememberLogin { get; set; }
    }
}