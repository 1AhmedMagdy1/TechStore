using Core.Interfaces;
using Core.Models;
using Core.Sharing;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class CartRepository : ICartRepository
    {
            private readonly IDatabase database;
    public CartRepository(IConnectionMultiplexer redis)
        {
            this.database = redis.GetDatabase();
        }

        public async Task<OperationResult> DeleteCart(string id)
        {

           var result= await database.KeyDeleteAsync(id);
            if(result)
                return OperationResult.OK("Cart deleted successfully", 200);
        return OperationResult.Fail("Cart not found", null, 404);
        }

        public async Task<OperationResult<Cart>> GetCartAsync(string id)
        {
            var cart =await  database.StringGetAsync(id);
            if (!string.IsNullOrEmpty(cart))
            {
                return OperationResult<Cart>
                    .OK(JsonSerializer.Deserialize<Cart>(cart)!,"cart fetched successfully",200);
            }
            
            return OperationResult<Cart>.Fail("Cart not found", null, 404);
        }

        public async Task<OperationResult<Cart>> Update(Cart cart)
        {
            //update
            
            var result=await  database.StringSetAsync(cart.Id,JsonSerializer.Serialize(cart),TimeSpan.FromDays(3));
            if (result)
            {
              return  await GetCartAsync(cart.Id);


            }
            return OperationResult<Cart>.Fail("Cart not found", null, 404);
        }
    }
}
