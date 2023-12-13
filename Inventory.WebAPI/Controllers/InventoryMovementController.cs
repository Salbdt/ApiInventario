using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Inventory.DTOs.InventoryMovement;

namespace Inventory.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryMovementController : ControllerBase
    {
        private readonly IInventoryMovementRepository _inventoryMovementRepository;
        private readonly IMapper _mapper;

        public InventoryMovementController(IInventoryMovementRepository inventoryMovementRepository, IMapper mapper)
        {
            _inventoryMovementRepository=inventoryMovementRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventoryMovement = await _inventoryMovementRepository.GetAllAsync();
            return Ok(_mapper.Map<List<InventoryMovementToListDTO>>(inventoryMovement));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventoryMovement = await _inventoryMovementRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<InventoryMovementToListDTO>(inventoryMovement));
        }

        [HttpPost]
        public async Task<IActionResult> Post(InventoryMovementToCreateDTO inventoryMovementToCreateDTO)
        {
            var inventoryMovementToCreate = _mapper.Map<InventoryMovement>(inventoryMovementToCreateDTO);
            var inventoryMovementCreated = await _inventoryMovementRepository.AddAsync(inventoryMovementToCreate);

            return Ok(_mapper.Map<InventoryMovementToListDTO>(inventoryMovementCreated));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InventoryMovementToEditDTO inventoryMovementToEditDTO)
        {
            if(id != inventoryMovementToEditDTO.Id)
                return BadRequest("Error en los datos de entrada")  ;

                var inventoryMovementToUpdate = await _inventoryMovementRepository.GetByIdAsync(id);
                if(inventoryMovementToUpdate is null)
                    return BadRequest("Error en los datos de entrada");

                _mapper.Map(inventoryMovementToEditDTO,inventoryMovementToUpdate);

                var updated = await _inventoryMovementRepository.UpdateAsync(id,inventoryMovementToUpdate);

                if(!updated)
                    return NoContent();
                
                var inventoryMovement = await _inventoryMovementRepository.GetByIdAsync(id);

                return Ok(_mapper.Map<InventoryMovementToListDTO>(inventoryMovement));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inventoryMovementToDelete = await _inventoryMovementRepository.GetByIdAsync(id);
            if(inventoryMovementToDelete is null)
                return NotFound("Id no encontrado");
            
            var deleted = await _inventoryMovementRepository.DeleteAsync(id);
            if(!deleted)
                return Ok("Registro no borrado consulte al administrados");
            
            return Ok("Registro borrado");
        }
    }
}