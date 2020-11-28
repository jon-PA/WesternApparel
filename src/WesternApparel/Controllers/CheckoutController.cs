using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;
using WesternApparel.Services;

namespace WesternApparel.Controllers
{
    [Authorize]
    [Route( "[controller]" )]
    public class CheckoutController : Controller
    {
        readonly ICartService _cartService;

        public CheckoutController( ICartService cartService )
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ViewResult> CheckoutView( [FromForm] AddToCartRequest request = null )
        {
            var user = HttpContext.User.GetSystemUser( );
            var userCart = await _cartService.GetCartAsync( user.ID );
            
            var vm = new CheckoutViewModel
            {
                Title = "Checkout",
                CartItems = userCart?.CartItems
            };

            return View( vm );
        }
    }
}