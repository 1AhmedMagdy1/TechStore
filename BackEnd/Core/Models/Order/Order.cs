using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Order
{
    public class Order : BaseModel<int>
    {

       
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; }
        public string FullName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        [RegularExpression(@"^01[0125]\d{8}$")]
        public string PhoneNumber { get; set; } = null!;
        public CustomerAddress CustomerAddress { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public DeliveryMethods DeliveryMethod { get; set; } = null!;
        public string PaymentMethod { get; set; }
        public decimal SubTotal { get; set; }


    }
}
