using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Order
{
    public class DeliveryMethods:BaseModel<int>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DeliveryTime { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
