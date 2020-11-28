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
        readonly SessionCartService _sessionCartService;
        readonly IProductRepository _productRepository;

        public CheckoutController( SessionCartService sessionCartService, IProductRepository productRepository )
        {
            _sessionCartService = sessionCartService;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<RedirectToActionResult> AddToCart( [FromForm(Name = "CartFormItem")] AddToCartRequest request )
        {
            var user = HttpContext.User.GetSystemUser( );

            var newCartItem = await _productRepository.FillCartItemInfo( request.ProductID );
            if( newCartItem is not null )
            {
                newCartItem.Quantity = request.Quantity;
                newCartItem.IsGiftItem = request.IsGiftItem;

                await _sessionCartService.AddItemToCartAsync( newCartItem, user.ID );
            }
            else
            {
                // TODO: Should do something to let the user know the cart item was not successfully added
            }

            return RedirectToAction( "CheckoutView"  );
        }

        [HttpGet]
        public async Task<ViewResult> CheckoutView( [FromForm] AddToCartRequest request = null )
        {
            var user = HttpContext.User.GetSystemUser( );
            var userCart = await _sessionCartService.GetCartAsync( user.ID );
            
            var vm = new CheckoutViewModel
            {
                Title = "Checkout",
                CartItems = userCart?.CartItems
            };

            return View( vm );
        }
    }
}