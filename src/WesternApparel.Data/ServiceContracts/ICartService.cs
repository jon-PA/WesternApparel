using System.Collections.Generic;
using System.Threading.Tasks;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Core.ServiceContracts
{
    public interface ICartService
    {
        Task<Cart> GetCartAsync( int userID );
        Task AddItemToCartAsync( CartItem cartItem, int userID );
    }
    
    public class Cart
    {
        public int SystemUserID { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}