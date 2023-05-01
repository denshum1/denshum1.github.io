using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Goods = new HashSet<Good>();
        }

        public int DId { get; set; }
        public int DUserId { get; set; }
        public string DStatus { get; set; } = null!;

        public virtual User DUser { get; set; } = null!;
        public virtual ICollection<Good> Goods { get; set; }
    }
}
