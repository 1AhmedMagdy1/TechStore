using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Cart
    {
        [Required]
        public string Id { get; set; } = null!;
        
 
        public CartItem[] CartItems { get; set; }=null!;
    }
}
