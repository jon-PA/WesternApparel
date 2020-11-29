using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.Cart;

namespace WesternApparel.Controllers
{
    [Authorize]
    [Route( "[controller]" )]
    public class CartController : Controller
    {
        readonly ICartService CartService;

        public CartController( ICartService cartService )
        {
            CartService = cartService;
        }

        [HttpGet]
        public async Task<ViewResult> CartView( )
        {
            var user = User.GetSystemUser( );
            
            return View( new CartViewModel
            {
                Cart = await CartService.GetCartAsync( user.ID )
            } );
        }
    }
}