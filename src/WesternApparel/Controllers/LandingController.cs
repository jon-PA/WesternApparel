using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Controllers
{
    [Route( "/" )]
    public class LandingController : Controller
    {
        [HttpGet]
        public ViewResult LandingView( )
        {
            return View( new BaseLayoutViewModel
            {
                Title = "Western Apparel"
            } );
        }
    }
}
