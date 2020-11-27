using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Controllers
{
    [Route( "[controller]" )]
    public class AccountController : Controller
    {
        [HttpGet( "login" )]
        public ViewResult LoginView( string returnUrl )
        {
            return View( "LoginView", new LoginViewModel( ) { ReturnUrl = returnUrl } );
        } 

        [HttpPost( "login" )]
        public IActionResult Login( LoginViewModel viewModel )
        {
            if( !ModelState.IsValid )
            {
                viewModel.Password = string.Empty;
                return View( "LoginView", viewModel );
            }

            var id = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim( ClaimTypes.Name, viewModel.EmailAddress )
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            string redirectUri = Url.Action( "LandingView", "Landing" );
            if( viewModel.ReturnUrl is not null && Url.IsLocalUrl( viewModel.ReturnUrl ) )
                redirectUri = viewModel.ReturnUrl;
            
            return SignIn(
                new ClaimsPrincipal( id ),

                new AuthenticationProperties
                {
                    RedirectUri = redirectUri,
                    IsPersistent = viewModel.RetainLogin
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );
        }

        [HttpGet( "logout" )]
        public SignOutResult Logout( )
        {
            return SignOut(
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action( "LandingView", "Landing" )
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );
        }

        [HttpGet( "register" )]
        public ViewResult RegisterView( )
        {
            return View( new BaseLayoutViewModel { Title = "Register - WesternApparel" } );
        }
    }
}
