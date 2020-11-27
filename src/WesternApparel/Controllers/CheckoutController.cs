using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Controllers
{
    [Authorize]
    [Route( "[controller]" )]
    public class CheckoutController : Controller
    {
        [HttpPost]
        public RedirectToActionResult AddToCart( [FromForm(Name = "CartFormItem")] AddToCartRequest request )
        {

            return RedirectToAction( "CheckoutView"  );
        }

        [HttpGet]
        public ViewResult CheckoutView( [FromForm] AddToCartRequest request = null )
        {
            var vm = new CheckoutViewModel
            {
                Title = "Checkout",
                CartItems = new List<CartItem>()
                {
                    new CartItem()
                    {
                        ProductID = 1,
                        ProductName = "Item 1",
                        Quantity = 1,
                        UnitProductPriceUSD = 15.00M,
                        IsGiftItem = true
                    },
                    new CartItem()
                    {
                        ProductID = 2,
                        ProductName = "Item 2",
                        Quantity = 3,
                        UnitProductPriceUSD = 5.00M,
                        IsGiftItem = false
                    },
                    new CartItem()
                    {
                        ProductID = 4,
                        ProductName = "Item 3",
                        UnitProductPriceUSD = 7.99M,
                        Quantity = 5,
                        IsGiftItem = false
                    },
                }
            };

            return View( vm );
        }
    }
}