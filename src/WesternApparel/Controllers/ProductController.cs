using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;
using WesternApparel.Services;

namespace WesternApparel.Controllers
{
    [Route( "shop/[controller]" )]
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;
        readonly ICartService _cartService;

        public ProductController( IProductRepository productRepository, ICartService cartService )
        {
            this._productRepository = productRepository;
            this._cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> ProductView( int id )
        {
            var vm = await _productRepository.FetchProductPageDataAsync( id );
            vm.CartFormItem = new AddToCartRequest
            {
                ProductID = id,
                Quantity = 1,
                IsGiftItem = false
            };

            return View( "ProductView", vm );
        }

        [HttpPost("{id?}")]
        public async Task<IActionResult> AddToCart( [FromForm(Name = "CartFormItem")] AddToCartRequest request )
        {
            if( !ModelState.IsValid )
                return await ProductView( request.ProductID );
            
            var user = HttpContext.User.GetSystemUser( );

            var newCartItem = await _productRepository.FillCartItemInfo( request.ProductID );
            if( newCartItem is not null )
            {
                newCartItem.Quantity = request.Quantity;
                newCartItem.IsGiftItem = request.IsGiftItem;

                await _cartService.AddItemToCartAsync( newCartItem, user.ID );
            }
            else
            {
                // TODO: Should do something to let the user know the cart item was not successfully added
            }

            return RedirectToAction( "CheckoutView", "Checkout" );
        }
    }
}
