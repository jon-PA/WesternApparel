using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WesternApparel.Core.Requests
{
    public class AddToCartRequest
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }
        public bool IsGiftItem { get; set; }
    }
}
