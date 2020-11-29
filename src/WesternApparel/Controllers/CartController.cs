using System;
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
        readonly ICartService _cartService;

        public CartController( ICartService cartService )
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ViewResult> CartView( )
        {
            var user = User.GetSystemUserOrThrow( );
            
            return View( new CartViewModel
            {
                Cart = await _cartService.GetCartAsync( user.ID )
            } );
        }

        [HttpGet("[action]")]
        public async Task<RedirectToActionResult> RemoveCartItem( Guid cartItemID )
        {
            var user = User.GetSystemUserOrThrow(  );
            
            await _cartService.RemoveItemFromCartAsync( user.ID, cartItemID );

            return RedirectToAction( "CartView" );
        }
    }
}