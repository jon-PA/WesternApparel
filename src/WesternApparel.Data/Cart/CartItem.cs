﻿using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.Cart
{
    public class CartItem
    {
        [Required] public int ProductID { get; set; }

        public string ProductName { get; set; }
        public decimal UnitProductPriceUSD { get; set; }

        [Required] [Range( 1, 10 )] public int Quantity { get; set; }

        public bool IsGiftItem { get; set; }
        public string ThumbnailURL { get; set; }
    }
}