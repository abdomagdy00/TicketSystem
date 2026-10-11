
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Application.Features.Categories.DTOs;
using TicketSystem.Application.Features.Categories.Interfaces;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAll()
        {
            var categories =await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if(category == null)
            {
                return NotFound(new {message =$"Category With ID {id} not found."});
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto dto)
        {
            var result = _categoryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById) ,new {id = result.Id},result);
        }
    }
}
