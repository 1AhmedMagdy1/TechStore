using AutoMapper;
using Core.DTOS;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories =mapper.Map<IReadOnlyList<CategoryDTO>>(await _categoryRepository.GatAllAsync()) ;
            return Ok(categories);
        }
    }
}
