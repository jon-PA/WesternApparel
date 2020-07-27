using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WesternApparel.ViewModels;

namespace WesternApparel.Areas.Shop.Controllers
{
    [Route( "shop/[controller]" )]
    public class ProductController : Controller
    {
        [HttpGet("{id}")]
        public ViewResult ProductView( int id )
        {
            return View( new BaseLayoutViewModel { Title = $"Product {id}" } );
        }
    }
}
