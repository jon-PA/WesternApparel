﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WesternApparel.Core.Cart
{
    public class CartItem
    {
        public Guid ID { get; set; }
        
        [Required] 
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public decimal UnitProductPriceUSD { get; set; }

        [Required] 
        [Range( 1, 10 )] 
        public int Quantity { get; set; }

        public bool IsGiftItem { get; set; }
        public string ThumbnailURL { get; set; }
        public string ShortDescription { get; set; }

        /// <summary>
        /// Returns true if both items are the same product, with the same configuration
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool RepresentsSameProduct( CartItem other ) =>
            other != null && this.ProductID == other.ProductID && this.IsGiftItem == other.IsGiftItem;
    }
}