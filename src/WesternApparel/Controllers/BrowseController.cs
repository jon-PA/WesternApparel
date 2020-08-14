using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Requests;
using WesternApparel.Core.ViewModels;
using WesternApparel.Core.ServiceContracts;
using System.Threading.Tasks;

namespace WesternApparel.Areas.Shop.Controllers
{
    [Route( "shop/[controller]" )]
    public class BrowseController : Controller
    {
        readonly IBrowseService BrowseService;

        public BrowseController( IBrowseService browseService )
        {
            this.BrowseService = browseService;
        }

        [HttpGet]
        public async Task<ViewResult> BrowseView( [FromForm] BrowseViewRequest request = null )
        {
            var vm = await BrowseService.FetchBrowsePageProductsAsync( request?.Category, 12, request?.Page ?? 1 );

            vm.Title = "Shop Western Apparel";

            return View( vm );
        }
    }
}
