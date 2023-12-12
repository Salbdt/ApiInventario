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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var categoryDTO = _mapper.Map<CategoryToListDTO>(category);

            return Ok(categoryDTO);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryToEditDTO categoryToEditDTO)
        {
            if (id != categoryToEditDTO.Id)
                return BadRequest("ERROR: Los datos ingresados son incorrectos.");

            var categoryToEdit = await _categoryRepository.GetByIdAsync(id);

            if (categoryToEdit is null)
                return BadRequest("ERROR: Elemento no encontrado.");

            _mapper.Map(categoryToEditDTO, categoryToEdit);
            categoryToEdit.UpdatedAt = DateTime.Now;

            var updated = await _categoryRepository.UpdateAsync(id, categoryToEdit);

            if (!updated)
                return NoContent();

            var category = await _categoryRepository.GetByIdAsync(id);
            var categoryDTO = _mapper.Map<CategoryToListDTO>(category);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(id);

            if (categoryToDelete is null)
                return NotFound("ERROR: Elemento no encontrado.");

            var deleted = await _categoryRepository.DeleteAsync(id);

            if (!deleted)
                return Ok("El elemento no se pudo eliminar.");

            return Ok("Elemento eliminado.");
        }
    }
}