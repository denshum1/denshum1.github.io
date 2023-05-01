using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Product
    {
        public Product()
        {
            Goods = new HashSet<Good>();
            ShopCarts = new HashSet<ShopCart>();
        }

        public int PId { get; set; }
        public string PName { get; set; } = null!;
        public bool PAvail { get; set; }
        public int PCategId { get; set; }

        public virtual Category PCateg { get; set; } = null!;
        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<ShopCart> ShopCarts { get; set; }
    }
}
