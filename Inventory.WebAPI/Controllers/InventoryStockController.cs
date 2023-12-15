using AutoMapper;
using Inventory.DTOs.InventoryStock;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.WebAPI.Controllers
{
    public class InventoryStockController : BaseApiController
    {
        private readonly IInventoryStockRepository _inventoryStockRepository;

        public InventoryStockController(IInventoryStockRepository inventoryStockRepository, IMapper mapper)
        : base(mapper)
        {
            _inventoryStockRepository=inventoryStockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventoryStocks = await _inventoryStockRepository.GetAllAsync();
            return Ok(_mapper.Map<List<InventoryStockToListDTO>>( inventoryStocks));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventoryStock = await _inventoryStockRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<InventoryStockToListDTO>( inventoryStock));
        }

        [HttpPost]
        public async Task<IActionResult> Post(InventoryStockToCreateDTO inventoryStockToCreateDTO)
        {
            var inventoryStockToCreate = _mapper.Map<InventoryStock>(inventoryStockToCreateDTO);
            inventoryStockToCreate.CreatedAt = DateTime.Now;
            var inventoryCreated = await _inventoryStockRepository.AddAsync(inventoryStockToCreate);

            return Ok(_mapper.Map<InventoryStockToListDTO>(inventoryCreated));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InventoryStockToEditDTO inventoryStockToEditDTO)
        {
            if(id != inventoryStockToEditDTO.Id)
                return BadRequest("Error en los datos de entrada");

            var inventoryStockToUpdate = await _inventoryStockRepository.GetByIdAsync(id);
            if(inventoryStockToUpdate is null)
                return BadRequest("Id no encontrado");
            
            _mapper.Map(inventoryStockToEditDTO,inventoryStockToUpdate);
            var updated = await _inventoryStockRepository.UpdateAsync(id,inventoryStockToUpdate);

            if(!updated)
                return NoContent();

            var inventoryStock = await _inventoryStockRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<InventoryStockToListDTO>(inventoryStock));            

        }



    }
}