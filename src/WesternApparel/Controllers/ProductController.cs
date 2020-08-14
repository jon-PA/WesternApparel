using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.ServiceContracts;
using WesternApparel.Core.ViewModels;
using WesternApparel.Requests;

namespace WesternApparel.Areas.Shop.Controllers
{
    [Route( "shop/[controller]" )]
    public class ProductController : Controller
    {
        readonly IProductService ProductService;

        public ProductController( IProductService productService )
        {
            this.ProductService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> ProductView( int id )
        {
            var vm = await ProductService.FetchProductPageDataAsync( id );

            return View( vm );
        }
    }
}
