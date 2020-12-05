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
        readonly IAuthenticationProvider _authenticationProvider;

        public AccountController( IAuthenticationProvider authenticationProvider )
        {
            _authenticationProvider = authenticationProvider;
        }

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

            var (error, user) =
                await _authenticationProvider.AuthenticateUser( viewModel.EmailAddress, viewModel.Password );

            if( error != AuthenticationResult.SUCCESS )
            {
                ( string errorField, string errorText ) = error switch
                {
                    AuthenticationResult.FAIL_UNKNOWN_USER => ( nameof( LoginViewModel.EmailAddress ),
                        "There is no user with the specified email address" ),
                    AuthenticationResult.FAIL_INVALID_PASSWORD => ( nameof( LoginViewModel.Password ),
                        "Password is invalid" ),
                    AuthenticationResult.FAIL_ACCOUNT_ISSUE => ( nameof( LoginViewModel.EmailAddress ),
                        "There is an issue with your user, please contact support" ),
                    AuthenticationResult.FAIL_PASSWORD_ERROR => ( nameof( LoginViewModel.Password ),
                        "There is an issue with your password, please click reset password below" ),
                    _ => ( nameof( LoginViewModel.EmailAddress ),
                        "There was an error authenticating, please contact support" )
                };
                    
                viewModel.Password = string.Empty;
                ModelState.AddModelError( errorField, errorText );

                return View( "LoginView", viewModel );
            }

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
            return View( "RegisterView", new RegisterViewModel { ReturnUrl = returnUrl } );
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