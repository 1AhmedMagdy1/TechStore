using Core.DTOS;
using Core.Models;
using Core.Models.Order;
using Core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<OperationResult> CreateOrderAsync(CreateOrderDTO orderDTO, string email);
        Task<OperationResult> GetOrdersAsync();
        Task<OperationResult<OrderDTo>> GetOrderByidAsync(int id);
        Task<OperationResult<List<DeliveryMethods>>> GetDeliveryMethods();
    }
}
