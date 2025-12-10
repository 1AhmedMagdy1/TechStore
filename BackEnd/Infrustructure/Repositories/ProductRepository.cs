using AutoMapper;
using Core.DTOS;
using Core.Interfaces;
using Core.Models;
using Core.Sharing;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly TechStoreContext context;
        private readonly IMapper mapper;

        public ProductRepository(TechStoreContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllAsync(ProductParams productParams)
        {
            var query=context.Products
                .Include(c => c.Category)
                .Include(p => p.ProductsPhotos).AsNoTracking();

            //filter by catgeory
            if (productParams.CategoryId.HasValue) {

              query= query.Where(c => c.CategoryId == productParams.CategoryId.Value);
            }

            if (!string.IsNullOrEmpty(productParams.SearchKeyWord))
            {
                query=query.Where(pr=>pr.ProductName.Contains(productParams.SearchKeyWord));
            }

            // filter by price Range
           
            if (productParams.MinPrice.HasValue && productParams.MaxPrice.HasValue && productParams.MaxPrice >= productParams.MinPrice) 
            {
                query=query.Where(pr=>pr.Price >= productParams.MinPrice.Value && pr.Price <= productParams.MaxPrice.Value);
            }
           
            //sorting asc or decs on price
            if (!string.IsNullOrEmpty(productParams.Sort)) {
                if (productParams.Sort.ToLower() == "asc") {

                    query = query.OrderBy(pr => pr.Price);
                }
                else if (productParams.Sort.ToLower() == "desc")
                {
                    query = query.OrderByDescending(pr => pr.Price);
                }

            }
            if (productParams.Stars.HasValue)
            {
                query=query.Where(st=>st.Stars>=productParams.Stars);
            }

            productParams.TotalCount = query.Count();

          query= query.Skip((productParams.PageNumber - 1) * productParams.PageSize)
                .Take(productParams.PageSize);
            var products= mapper.Map<IReadOnlyList<ProductDto>>(query.ToList());
            return products;
        }
        public Task<bool> AddAsync(AddProductDTo productDTo)
        {
            throw new NotImplementedException();
        }

        
    }
}
