using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WesternApparel.Core.Catalog;

namespace WesternApparel.Controllers
{
    [Route( "shop/[controller]" )]
    public class CatalogController : Controller
    {
        readonly ICatalogRepository _catalogRepository;

        public CatalogController( ICatalogRepository catalogRepository )
        {
            this._catalogRepository = catalogRepository;
        }

        [HttpGet("{Category?}")]
        public async Task<ViewResult> BrowseView( BrowseViewRequest request = null )
        {
            if( request is not null && request.Category != null )
                request.Category = request.Category.Replace( "%2F", "/", StringComparison.OrdinalIgnoreCase );
            
            var vm = await _catalogRepository.FetchBrowsePageProductsAsync( new BrowseViewRequest
            {
                Category = request?.Category, 
                PageSize = 24, 
                Page = request?.Page ?? 1
            });

            vm.Category = request?.Category;

            return View( vm );
        }
    }
}
