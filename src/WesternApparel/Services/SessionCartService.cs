using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WesternApparel.Core.Cart;

namespace WesternApparel.Services
{
    public class SessionCartService : ICartService
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public SessionCartService( IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        async ValueTask<ISession> GetSession( )
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if( !httpContext.Session.IsAvailable )
                await httpContext.Session.LoadAsync( );

            return httpContext.Session;
        }

        string CartKey( int userID ) => $"USER_CART:{userID}";
        
        public Task<Cart> GetCartAsync( ISession session, int userID )
        {
            return Task.FromResult( session.Get<Cart>( CartKey( userID )));
        }
        
        public async Task<Cart> GetCartAsync( int userID )
        {
            var session = await GetSession( );
            
            return session.Get<Cart>( CartKey( userID ) );
        }

        public async Task AddItemToCartAsync( CartItem cartItem, int userID )
        {
            var session = await GetSession( );

            var existingCart = await GetCartAsync( session, userID );
            if( existingCart == null )
                existingCart = new Cart
                {
                    SystemUserID = userID,
                    CartItems = new List<CartItem>( )
                };

            var itemInCart = existingCart.CartItems.FirstOrDefault( ci => ci.ProductID == cartItem.ProductID && ci.IsGiftItem == cartItem.IsGiftItem );
            if( itemInCart != null )
            {
                // The item was already in the cart with the same specs, just increase number
                itemInCart.Quantity += cartItem.Quantity;
            }
            else
            {
                // The item with matching parameters was not in the cart, add new
                existingCart.CartItems.Add( cartItem );
            }
            
            session.Set( CartKey( userID ), existingCart );
        }
    }
}