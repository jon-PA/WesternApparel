using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.ViewModels;

namespace WesternApparel.Areas.Shop.Controllers
{
    [Area("Shop")]
    public class BrowseController : Controller
    {
        public ViewResult Index( )
        {
            return View( new BaseLayoutViewModel { Title = "Shop Western Apparel" } );
        }
    }
}
