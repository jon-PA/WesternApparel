using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.Cart
{
    public class AddToCartRequest
    {
        [Required] public int ProductID { get; set; }

        [Required]
        [Range( 1, 10, ErrorMessage = "Number of items must be between 1 and 10" )]
        public int Quantity { get; set; }

        public bool IsGiftItem { get; set; }
    }
}