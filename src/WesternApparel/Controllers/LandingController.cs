using Microsoft.AspNetCore.Mvc;
using WesternApparel.Core.Common;

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
                Title = "Landing"
            } );
        }
    }
}
