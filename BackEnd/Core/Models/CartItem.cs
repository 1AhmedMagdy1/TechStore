using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = null!;
        [Required]
        public string Category { get; set; } = null!;
        [Range(0,double.MaxValue,ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }
        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
        public int Discount { get; set; }
        [Required]
        public string ProductPhoto { get; set; } = null!;



        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}