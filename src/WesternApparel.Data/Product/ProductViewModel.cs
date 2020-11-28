using WesternApparel.Core.Cart;
using WesternApparel.Core.Common;

namespace WesternApparel.Core.Product
{
    public class ProductViewModel : BaseLayoutViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string DisplayPrice { get; set; }

        public string Category { get; set; }

        /// <summary>
        ///     Value may include markup. Ensure script and other hazardous tags are removed before serving.
        /// </summary>
        public string ProductShortDescription { get; set; }

        public string ProductFullDescription { get; set; }

        public string ThumbnailURL { get; set; }

        public AddToCartRequest CartFormItem { get; set; }
    }
}