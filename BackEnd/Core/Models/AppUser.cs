using Core.Models.Order;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Enter a valid Egyptian mobile number (e.g. 01012345678).")]
        public override string PhoneNumber { get; set; }
        public ICollection<Order.Order> Orders { get; set; } = new List<Order.Order>();
        public ICollection<CustomerAddress>  CustomerAddresses { get; set; } = new List<CustomerAddress>();
    }

}
