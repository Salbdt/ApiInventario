using Inventory.DTOs.Category;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryToCreateDTO categoryToCreateDTO)
        {
            var categoryToCreate = new Category
            {
                Name = categoryToCreateDTO.Name,
                Description = categoryToCreateDTO.Description,
                CreatedAt = DateTime.Now
            };

            var categoryCreated = await _categoryRepository.AddAsync(categoryToCreate);

            var categoryCreatedDTO = new CategoryToListDTO
            {
                Id = categoryCreated.Id,
                Name = categoryCreated.Name,
                Description = categoryCreated.Description,
                CreatedAt = categoryCreated.CreatedAt,
                UpdatedAt = categoryCreated.UpdatedAt
            };

            return Ok(categoryCreatedDTO);
        }
    }
}