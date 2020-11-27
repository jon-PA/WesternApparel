using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WesternApparel.Core.Requests;

namespace WesternApparel.Core.ViewModels
{
    public class CartItem
    {
        [Required]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitProductPriceUSD { get; set; }
        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }
        public bool IsGiftItem { get; set; }
    }
    
    public class CheckoutViewModel : BaseLayoutViewModel
    {
        public List<CartItem> CartItems { get; set; }
    }
}