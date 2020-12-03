using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core;
using WesternApparel.Core.Account;
using WesternApparel.Core.Common;

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
        public async Task<IActionResult> Login( LoginViewModel viewModel )
        {
            if( !ModelState.IsValid )
            {
                viewModel.Password = string.Empty;
                return View( "LoginView", viewModel );
            }

            var user = new SystemUser
            {
                ID = 10001,
                EmailAddress = viewModel.EmailAddress
            };
            var id = new ClaimsIdentity(
                user.GetPrincipalClaims( ),
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            string redirectUri;
            if( viewModel.ReturnUrl is not null && Url.IsLocalUrl( viewModel.ReturnUrl ) )
                redirectUri = viewModel.ReturnUrl;
            else
                redirectUri = Url.Action( "LandingView", "Landing" );
            
            await HttpContext.SignInAsync( 
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal( id ),

                new AuthenticationProperties
                {
                    IsPersistent = viewModel.RetainLogin
                }
            );

            return LocalRedirect( redirectUri );
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
        public ViewResult RegisterView( string returnUrl )
        {
            return View( "RegisterView", new RegisterViewModel{ ReturnUrl = returnUrl } );
        }

        [HttpPost( "register" )]
        public async Task<IActionResult> Register( RegisterViewModel viewModel )
        {
            if( !ModelState.IsValid )
            {
                viewModel.Password = string.Empty;
                viewModel.ConfirmPassword = string.Empty;
                return View( "RegisterView", viewModel );
            }

            var user = new SystemUser
            {
                ID = 10001,
                EmailAddress = viewModel.EmailAddress
            };
            var id = new ClaimsIdentity(
                user.GetPrincipalClaims( ),
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            string redirectUri;
            if( viewModel.ReturnUrl is not null && Url.IsLocalUrl( viewModel.ReturnUrl ) )
                redirectUri = viewModel.ReturnUrl;
            else
                redirectUri = Url.Action( "LandingView", "Landing" );
            
            await HttpContext.SignInAsync( 
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal( id ),

                new AuthenticationProperties
                {
                    IsPersistent = viewModel.RetainLogin
                }
            );

            return LocalRedirect( redirectUri );
        }
    }
}
