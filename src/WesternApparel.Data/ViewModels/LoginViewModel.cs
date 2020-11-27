using System;
using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.ViewModels
{
    public class LoginViewModel : BaseLayoutViewModel
    {
        public LoginViewModel( )
        {
            this.Title = "Log in";
        }

        public string ReturnUrl { get; set; }
     
        [Required( ErrorMessage = "Must provide a valid email address")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required( ErrorMessage = "Must provide a valid password")]
        public string Password { get; set; }
        public bool RetainLogin { get; set; }
        
    }
}