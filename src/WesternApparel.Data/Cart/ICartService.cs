using System;
using System.Threading.Tasks;

namespace WesternApparel.Core.Cart
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync( int userID );
        Task AddItemToCartAsync( int userID, CartItem cartItem );
        Task RemoveItemFromCartAsync( int userID, Guid cartItemID );
    }
}