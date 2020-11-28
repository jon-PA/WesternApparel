using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using WesternApparel.Core;

namespace WesternApparel
{
    public static class UserPrincipalExtensions
    {
        public static SystemUser GetSystemUser( this IPrincipal _principal )
        {
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

        // TODO: public static SystemUser GetSystemUserOrThrow( this IPrincipal _principal )
    
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