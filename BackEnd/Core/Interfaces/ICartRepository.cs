using Core.Models;
using Core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        Task<OperationResult<Cart>> Update(Cart cart);
        Task<OperationResult<Cart>> GetCartAsync(string id);
        Task<OperationResult> DeleteCart(string id);
    }
}
