using System.Threading.Tasks;

namespace WesternApparel.Core.Account
{
    public enum AuthenticationResult
    {
        /// <summary>
        /// The provided email address does not correspond to an existing user
        /// </summary>
        FAIL_UNKNOWN_USER,
        /// <summary>
        /// The provided password does not match the user that was found
        /// </summary>
        FAIL_INVALID_PASSWORD,
        /// <summary>
        /// There is a critical issue with how the User is set up that prevents authentication
        /// </summary>
        FAIL_ACCOUNT_ISSUE,
        /// <summary>
        /// There is a critical issue with the user's existing password that prevents authentication
        /// </summary>
        FAIL_PASSWORD_ERROR,
        
        SUCCESS,
    }
    public interface IAuthenticationProvider
    {
        Task<(AuthenticationResult authResult, SystemUser user)> AuthenticateUser( string emailAddress, string password );
    }
}