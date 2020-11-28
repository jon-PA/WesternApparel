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
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required( ErrorMessage = "Must provide a valid password" )]
        public string Password { get; set; }

        public bool RetainLogin { get; set; }
    }
}