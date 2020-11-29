using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using WesternApparel.Core;

namespace WesternApparel
{
    public static class UserPrincipalExtensions
    {
        /// <summary>
        /// Attempts to convert the principal into a valid SystemUser, or returns null
        /// </summary>
        /// <returns>SystemUser?</returns>
        public static SystemUser GetSystemUser( this IPrincipal _principal )
        {
            if( _principal is null )
                throw new ArgumentNullException( nameof( _principal ) );
            
            if( _principal is not ClaimsPrincipal principal
             || principal.Identity is not ClaimsIdentity identity
             || !identity.IsAuthenticated  )
                return null;

            var systemUser = new SystemUser( );

            var systemUserIDString = identity.FindFirst( "SystemUserID" )?.Value;
            if( !string.IsNullOrEmpty( systemUserIDString ) && int.TryParse( systemUserIDString, out int systemUserID ) )
            {
                systemUser.ID = systemUserID;
            }
            else
            {
                return null;
            }

            var systemUserEmailString = identity.FindFirst( "SystemUserEmail" )?.Value;
            if( !string.IsNullOrEmpty( systemUserEmailString ) )
                systemUser.EmailAddress = systemUserEmailString;

            return systemUser;
        }

        /// <summary>
        /// Attempts to convert the principal into a valid SystemUser, or throws an UnauthorizedAccessException.
        /// </summary>
        public static SystemUser GetSystemUserOrThrow( this IPrincipal _principal )
        {
            return GetSystemUser( _principal ) ?? throw new UnauthorizedAccessException( "Principal did not represent a valid system user" );;
        }
    
        public static List<Claim> GetPrincipalClaims( this SystemUser systemUser )
        {
            return new List<Claim>
            {
                new Claim( ClaimTypes.Name, systemUser.EmailAddress ),
                
                new Claim( "SystemUserID", systemUser.ID.ToString( ) ),
                new Claim( "SystemUserEmail", systemUser.EmailAddress )
            };
        }
    }
}