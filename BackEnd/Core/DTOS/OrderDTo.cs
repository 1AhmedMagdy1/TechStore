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
    public class OrderDTo
    {
       
       
        public string PhoneNumber { get; set; } = null!;
        public CustomerAddress CustomerAddress { get; set; } = null!;
        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

        public DeliveryMethodDTO DeliveryMethod { get; set; } = null!;
        public string PaymentMethod { get; set; }
        public decimal SubTotal { get; set; }
    }
}
