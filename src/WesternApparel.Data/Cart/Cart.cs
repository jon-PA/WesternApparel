using System.Collections.Generic;

namespace WesternApparel.Core.Cart
{
    public class Cart
    {
        public int SystemUserID { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}