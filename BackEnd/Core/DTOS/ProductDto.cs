using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? CategoryName { get; set; }
        public decimal Price { get; set; }
        public decimal Stars { get; set; }
        public int NumberOfReviewers { get; set; }
        public int Discount { get; set; }
        public string ProductDetails { get; set; }
        public string KeyFeatures { get; set; }
        public IEnumerable<ProductPhotoDto> ProductsPhotos { get; set; }
    }
}
