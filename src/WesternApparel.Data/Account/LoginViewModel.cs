using System.ComponentModel.DataAnnotations;
using WesternApparel.Core.Common;

namespace WesternApparel.Core.Account
{
    public class LoginViewModel : BaseLayoutViewModel
    {
        public LoginViewModel( ) : base( "Log in" )
        { }

        public string ReturnUrl { get; set; }

        [Required( ErrorMessage = "Must provide a valid email address" )]
        [EmailAddress( ErrorMessage = "Must provide a valid email address")]
        public string EmailAddress { get; set; }

        [Required( ErrorMessage = "Must provide a valid password" )]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "Passwords must be between 2 and 24 characters long")]
        public string Password { get; set; }

        public bool RetainLogin { get; set; }
    }
}