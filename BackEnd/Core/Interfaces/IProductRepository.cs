using Core.DTOS;
using Core.Models;
using Core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<IReadOnlyList<ProductDto>> GetAllAsync(ProductParams productParams);
        public Task<bool> AddAsync(AddProductDTo productDTo);


    }
}
