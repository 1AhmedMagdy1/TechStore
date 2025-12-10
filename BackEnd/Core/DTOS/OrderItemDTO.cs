using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class OrderItemDTO
    {
      
        public string ProductName { get; set; }
       
       
        public string ProductDetails { get; set; }
     
        public virtual Categoty Category { get; set; }

        public virtual string ProductsPhoto { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
