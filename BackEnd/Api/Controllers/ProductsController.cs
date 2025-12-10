using Api.Helper;
using AutoMapper;
using Core.DTOS;
using Core.Interfaces;
using Core.Sharing;
using Infrustructure.Data;
using Infrustructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IProductRepository productRepository)
        {

            _mapper = mapper;
            this.productRepository = productRepository;
        }
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] ProductParams productParams)
        {
            try {
                var products=await productRepository.GetAllAsync(productParams);
                if(products == null )
                {
                    return NotFound("No products found.");
                }

                return Ok(new Pagination<ProductDto>
               (productParams.PageNumber,productParams.PageSize,productParams.TotalCount,products));

            }
            catch (Exception ex){ 
            
            return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product=await productRepository.GetByIdAsync(id,c=>c.Category,ph=>ph.ProductsPhotos);
            if (product is null) return NotFound("product not found");
            return Ok(_mapper.Map<ProductDto>(product));

        }

    }
}
