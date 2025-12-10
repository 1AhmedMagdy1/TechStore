#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsPhotos = new List<ProductsPhoto>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }           
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public int NumberOfReviewers { get; set; }
        public int Discount { get; set; }
        public string ProductDetails { get; set; }
        public string KeyFeatures { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Categoty Category { get; set; }

        public virtual ICollection<ProductsPhoto> ProductsPhotos { get; set; }
    }
}
