using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class User
    {
        public User()
        {
            Deliveries = new HashSet<Delivery>();
            ShopCarts = new HashSet<ShopCart>();
        }

        public int UId { get; set; }
        public string ULogin { get; set; } = null!;
        public string UPassword { get; set; } = null!;

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<ShopCart> ShopCarts { get; set; }
    }
}
