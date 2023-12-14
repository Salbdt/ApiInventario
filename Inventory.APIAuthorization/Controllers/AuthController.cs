using Inventory.DTOs.Auth;
using Inventory.Entities;
using Inventory.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.APIAuthorization.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {
            if (await _authRepository.UserExists(userToRegisterDTO.Email))
                return BadRequest($"El email {userToRegisterDTO.Email} ya se encuentra registrado.");

            var userToCreate = new User
            {
                Name = userToRegisterDTO.Name,
                Email = userToRegisterDTO.Email,
                Phone = userToRegisterDTO.Phone,
                DateCreated = DateTime.Now,
                Active = true
            }

            var userCreated = await _authRepository.Register(userToCreate, userToRegisterDTO.Password);

            var userToReturn = new UserToListDTO(userCreated.Id, userCreated.Email, userCreated.Name, userCreated.Phone, "");

            return Ok(userToReturn);
        }
    }
}