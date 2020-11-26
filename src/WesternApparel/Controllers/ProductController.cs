using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.Requests;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Controllers
{
    [Route( "shop/[controller]" )]
    public class ProductController : Controller
    {
        readonly IProductRepository _productRepository;

        public ProductController( IProductRepository productRepository )
        {
            this._productRepository = productRepository;
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

            return View( vm );
        }
    }
}
