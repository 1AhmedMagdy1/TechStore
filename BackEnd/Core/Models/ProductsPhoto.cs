#nullable disable
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public partial class ProductsPhoto
    {
        public int Id { get; set; }

        // required FK to Product
        public int ProductId { get; set; }

        public string ImageURL { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
