using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.ViewModels;

namespace WesternApparel.Areas.Shop.Controllers
{
    [Route( "shop/[controller]" )]
    public class BrowseController : Controller
    {
        [HttpGet]
        public ViewResult BrowseView( )
        {
            return View( new BaseLayoutViewModel { Title = "Shop Western Apparel" } );
        }
    }
}
