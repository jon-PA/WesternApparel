using System.Collections.Generic;
using WesternApparel.Core.Cart;
using WesternApparel.Core.Common;

namespace WesternApparel.Core.Checkout
{
    public class CheckoutViewModel : BaseLayoutViewModel
    {
        public CheckoutViewModel( ) : base( "Checkout" )
        { }

        public List<CartItem> CartItems { get; set; }
    }
}