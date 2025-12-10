using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class AddProductDTo
    {
       
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public int NumberOfReviewers { get; set; }
        public int Discount { get; set; }
        public string ProductDetails { get; set; }
        public string KeyFeatures { get; set; }

        
        

       
    }
}
