using AutoMapper;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Inventory.DTOs.Product;
namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
          _productRepository = productRepository;   
          _mapper= mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            return Ok(_mapper.Map<List<ProductToListDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GEtById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            

            return Ok(_mapper.Map<ProductToListDTO>(product));
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProductToCreateDTO productToCreateDTO)
        {
            var productToCreate = _mapper.Map<Product>(productToCreateDTO);
            productToCreate.CreatedAt= DateTime.Now;
            var productCreated = await _productRepository.AddAsync(productToCreate);

            return Ok( _mapper.Map<ProductToListDTO>(productCreated));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductToEditDTO productToEditDTO)
        {
            if( id != productToEditDTO.Id)
                return BadRequest();

            var productToUpdate = await _productRepository.GetByIdAsync(id);
            if(productToUpdate is null)
                return BadRequest("Id no encontrado");

            _mapper.Map(productToEditDTO,productToUpdate);
            
            productToUpdate.UpdatedAt = DateTime.Now;
            var updated = await _productRepository.UpdateAsync(id,productToUpdate);
            if(!updated)
                return NoContent();

            var product = await _productRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductToListDTO>(product));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var prodcutToDelete = await _productRepository.GetByIdAsync(id);

            if(prodcutToDelete is null)
            return NotFound("Producto no encontrado");

            var deleted = await _productRepository.DeleteAsync(prodcutToDelete);

            if(!deleted)
                return Ok("Producto no borrado contacte al administrador");
            
            return Ok("El producto fue borrado");
        }

    }
}