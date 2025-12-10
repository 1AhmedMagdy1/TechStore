using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Order
{
    public class CustomerAddress:BaseModel<int>
    {
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Postal code must be exactly 5 digits.")]
        public string PostalCode { get; set; }=null!;
        public string  City { get; set; } = null!;
        public string ShippingAddress { get; set; } = null!;
        public string UserId { get; set; }
        public AppUser User { get; set; } = null!;
    }
}
