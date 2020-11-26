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
        public ViewResult LoginView( )
        {
            return View( new BaseLayoutViewModel { Title = "Log in - WesternApparel" } );
        }

        [HttpPost( "login" )]
        public SignInResult Login( )
        {
            var id = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim( ClaimTypes.Name, "joe_mama" )
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return SignIn(
                new ClaimsPrincipal( id ),

                new AuthenticationProperties
                {
                    RedirectUri = Url.Action( "LandingView", "Landing" )
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
