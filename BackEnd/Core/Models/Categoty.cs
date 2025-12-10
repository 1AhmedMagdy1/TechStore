#nullable disable
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Categoty
    {
        public Categoty()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }

        // navigation: 1 category -> many products
        public virtual ICollection<Product> Products { get; set; }
    }
}
