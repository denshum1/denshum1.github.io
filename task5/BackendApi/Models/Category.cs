using System;
using System.Collections.Generic;

namespace BackendApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CId { get; set; }
        public string CName { get; set; } = null!;
        public string CDescr { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
