using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class ShopCart
    {
        public int SUserId { get; set; }
        public int SProductId { get; set; }
        public int SAmountOfProd { get; set; }

        public virtual Product SProduct { get; set; } = null!;
        public virtual User SUser { get; set; } = null!;
    }
}
