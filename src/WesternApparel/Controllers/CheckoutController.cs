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