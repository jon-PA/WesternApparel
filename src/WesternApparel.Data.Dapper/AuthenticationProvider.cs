using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using Dapper;
using WesternApparel.Core;
using WesternApparel.Core.Account;

namespace WesternApparel.Data.Dapper
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        readonly IDbConnection Connection;

        public AuthenticationProvider( IDbConnection connection )
        {
            this.Connection = connection;
        }
        
        public async Task<(AuthenticationResult authResult, SystemUser user)> AuthenticateUser( string emailAddress, string password )
        {
            if( string.IsNullOrEmpty(emailAddress) )
                throw new ArgumentNullException( nameof( emailAddress ) );
            if( string.IsNullOrEmpty(password) )
                throw new ArgumentNullException( nameof( password ) );
            
            var users = await Connection.QueryAsync<SystemUser, string, (SystemUser user, string passwordHash)>(
                @"SELECT 
                    ID, 
                    EmailAddress,
                    PasswordHash
                  FROM Users
                  WHERE EmailAddress LIKE @EmailAddress;
                  ",
                ( user, s ) => (user, s), 
            
                new { 
                    EmailAddress = emailAddress,
                },
                splitOn: "PasswordHash"
            );

            var (systemUser, passwordHash) = users.FirstOrDefault( );
            
            if( systemUser is null )
                return (AuthenticationResult.FAIL_UNKNOWN_USER, null);
            
            if( string.IsNullOrEmpty( systemUser.EmailAddress ))
                return (AuthenticationResult.FAIL_ACCOUNT_ISSUE, null);

            try
            {
                if( BCrypt.Net.BCrypt.EnhancedVerify( password, passwordHash ) )
                    return ( AuthenticationResult.SUCCESS, systemUser );
                else
                    return ( AuthenticationResult.FAIL_INVALID_PASSWORD, null );
            }
            catch( SaltParseException spe )
            {
                return ( AuthenticationResult.FAIL_PASSWORD_ERROR, null );
            }

        }
    }
}