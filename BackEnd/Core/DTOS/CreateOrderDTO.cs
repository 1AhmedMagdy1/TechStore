using Core.Models.Order;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public class CreateOrderDTO
    {
        public string CartID { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public CustomerAddressDTO CustomerAddress { get; set; } = null!;
        public int DeliveryMethodId { get; set; }
        public string PaymentMethod { get; set; }
        
    }
}
