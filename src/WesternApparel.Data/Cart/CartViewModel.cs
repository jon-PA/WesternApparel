using WesternApparel.Core.Common;

namespace WesternApparel.Core.Cart
{
    public class CartViewModel : BaseLayoutViewModel
    {
        public CartViewModel( ) : base( "Cart" )
        { }
        
        public Cart Cart { get; set; }
    }
}