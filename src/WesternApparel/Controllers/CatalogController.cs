using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.ViewModels;
using WesternApparel.Core.ServiceContracts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WesternApparel.Core.Requests;

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

            vm.Title = "Shop Western Apparel";
            vm.Category = request?.Category;

            return View( vm );
        }
    }
}
