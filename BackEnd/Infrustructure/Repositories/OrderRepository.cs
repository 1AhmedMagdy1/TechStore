using Core.DTOS;
using Core.Interfaces;
using Core.Models;
using Core.Models.Order;
using Core.Sharing;
using Infrustructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TechStoreContext _context;
        private readonly UserManager<AppUser> usermanager;
        private readonly ICartRepository cartRepository;

        public OrderRepository(TechStoreContext context, UserManager<AppUser> usermanager, ICartRepository cartRepository)
        {
            _context = context;
            this.usermanager = usermanager;
            this.cartRepository = cartRepository;
        }


        public async Task<OperationResult> CreateOrderAsync(CreateOrderDTO orderDTO,string email)
        {
            try
            {


                var user = await usermanager.FindByEmailAsync(email);
                if (user is null)
                {
                    return OperationResult.Fail("User Not Found", null, 404);
                }
                var cartResult = await cartRepository.GetCartAsync(orderDTO.CartID);
                if (!cartResult.Success || cartResult.Data is null)
                {
                    return OperationResult.Fail("Cart Not Found", null, 404);
                }
              
                var deliveryMethod = await _context.DeliveryMethods
                    .FirstOrDefaultAsync(dm => dm.Id == orderDTO.DeliveryMethodId);


                var customeraddress = new CustomerAddress
                {
                    City = orderDTO.CustomerAddress.City,
                    PostalCode = orderDTO.CustomerAddress.PostalCode,
                    ShippingAddress = orderDTO.CustomerAddress.ShippingAddress,
                    UserId = user.Id,
                };
                var order = new Order
                {
                    UserId=user.Id,
                    Email = email,
                    PaymentMethod = orderDTO.PaymentMethod,
                    PhoneNumber = orderDTO.PhoneNumber,
                    DeliveryMethod = deliveryMethod,
                    FullName = user.UserName,
                    OrderItems = new List<OrderItem>(),
                   CustomerAddress=customeraddress
                };
                var orderItems = new List<OrderItem>();
                var cart = cartResult.Data;
                foreach (var item in cart.CartItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(pr => pr.Id == item.Id);
                    if (product is null)
                    {
                        return OperationResult.Fail($"Product with id {item.Id} Not Found", null, 400);
                    }
                    var orderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        UnitPrice = product.Price,
                        Quantity = item.Quantity,

                    };

                    orderItems.Add(orderItem);
                }

                order.OrderItems = orderItems;
                var subtotal = orderItems.Sum(oi => oi.UnitPrice * oi.Quantity);
                order.SubTotal = subtotal;
                

               
                
                await _context.CustomerAddresses.AddAsync(customeraddress);
                await _context.Orders.AddAsync(order);

                await _context.SaveChangesAsync();

               await cartRepository.DeleteCart(orderDTO.CartID);
                return OperationResult.OK("Order Created Successfully", 201);
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Error while creating order", null, 500);
            }
           
           
        }

        public async Task<OperationResult<OrderDTo>> GetOrderByidAsync(int id)
        {
           var Order=await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (Order is null)
                return  OperationResult<OrderDTo>.Fail("Order Not Found", null, 404);

            var delivery = new DeliveryMethodDTO
            {
                Name = Order.DeliveryMethod.Name,
                DeliveryTime = Order.DeliveryMethod.DeliveryTime,
                Description = Order.DeliveryMethod.Description,
                Price = Order.DeliveryMethod.Price
            };
            var orderitems=new List<OrderItemDTO>();
            foreach (var item in Order.OrderItems)
            {
                var orderitemdto=new OrderItemDTO
                {
                    Category = item.Product.Category,
                    ProductDetails=item.Product.ProductDetails,
                    ProductName = item.Product.ProductName,
                    ProductsPhoto = item.Product.ProductsPhotos.FirstOrDefault().ImageURL,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                };
                orderitems.Add(orderitemdto);

            }
            var OrderDto = new OrderDTo
            {
                PhoneNumber = Order.PhoneNumber,
                SubTotal = Order.SubTotal,
                PaymentMethod = Order.PaymentMethod,
                CustomerAddress = Order.CustomerAddress,
                DeliveryMethod = delivery,
                OrderItems=orderitems
            };
            return OperationResult<OrderDTo>.OK(OrderDto, "Done", 200);
        }

        public Task<OperationResult> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<List<DeliveryMethods>>> GetDeliveryMethods()
        {
            try
            {
                var methods = await _context.DeliveryMethods.ToListAsync();
                if (methods is null || !methods.Any())
                {
                    return OperationResult<List<DeliveryMethods>>.Fail("No Delivery Methods Found", null, 404);
                }

                return OperationResult<List<DeliveryMethods>>.OK(methods, "Done", 200);
            }
            catch (Exception ex) {

                return OperationResult<List<DeliveryMethods>>.Fail("Error while getting Delivery mwthods", null, 500);
            }
            
        }

       
    }
}
