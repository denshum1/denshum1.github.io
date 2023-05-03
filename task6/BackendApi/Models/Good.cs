using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Good
    {
        public int GProdId { get; set; }
        public int GDelivId { get; set; }
        public int GMethod { get; set; }

        public virtual Delivery GDeliv { get; set; } = null!;
        public virtual Product GProd { get; set; } = null!;
    }
}
