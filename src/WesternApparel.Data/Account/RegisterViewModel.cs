using System.ComponentModel.DataAnnotations;
using WesternApparel.Core.Common;

namespace WesternApparel.Core.Account
{
    public class RegisterViewModel : BaseLayoutViewModel
    {
        public RegisterViewModel( ) : base( "Register" )
        { }

        public string ReturnUrl { get; set; }
        
        [Required(ErrorMessage = "Must provide a valid email address")]
        [EmailAddress(ErrorMessage = "Must provide a valid email address")]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Passwords must be between 2 and 24 characters long")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
        public bool RetainLogin { get; set; }
    }
}