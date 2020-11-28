using System.Collections.Generic;
using WesternApparel.Core.ViewModels;

namespace WesternApparel.Services
{
    public class Cart
    {
        public int SystemUserID { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}