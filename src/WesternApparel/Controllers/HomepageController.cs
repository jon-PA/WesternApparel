using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.ViewModels;

namespace WesternApparel.Controllers
{
    [Route("/")]
    public class HomepageController : Controller
    {
        public ViewResult Index( )
        {
            return View( new BaseLayoutViewModel
            {
                Title = "Home"
            } );
        }
    }
}
