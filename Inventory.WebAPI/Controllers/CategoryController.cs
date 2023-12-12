using AutoMapper;
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
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesDTO = _mapper.Map<List<CategoryToListDTO>>(categories);

            return Ok(categoriesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryToCreateDTO categoryToCreateDTO)
        {
            // var categoryToCreate = new Category
            // {
            //     Name = categoryToCreateDTO.Name,
            //     Description = categoryToCreateDTO.Description,
            //     CreatedAt = DateTime.Now
            // };
            var categoryToCreate = _mapper.Map<Category>(categoryToCreateDTO);
            categoryToCreate.CreatedAt = DateTime.Now;

            var categoryCreated = await _categoryRepository.AddAsync(categoryToCreate);

            // var categoryCreatedDTO = new CategoryToListDTO
            // {
            //     Id = categoryCreated.Id,
            //     Name = categoryCreated.Name,
            //     Description = categoryCreated.Description,
            //     CreatedAt = categoryCreated.CreatedAt,
            //     UpdatedAt = categoryCreated.UpdatedAt
            // };
            var categoryCreatedDTO = _mapper.Map<CategoryToListDTO>(categoryCreated);

            return Ok(categoryCreatedDTO);
        }
    }
}