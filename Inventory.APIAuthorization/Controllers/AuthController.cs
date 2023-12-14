using Inventory.APIAuthorization.Services.Interfaces;
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
        private readonly ITokenService _tokenService;

        public AuthController(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserToRegisterDTO userToRegisterDTO)
        {
            if (await _authRepository.UserExists(userToRegisterDTO.Email.ToLower()))
                return BadRequest($"El email {userToRegisterDTO.Email} ya se encuentra registrado.");

            var userToCreate = new User
            {
                Name = userToRegisterDTO.Name,
                Email = userToRegisterDTO.Email.ToLower(),
                Phone = userToRegisterDTO.Phone,
                DateCreated = DateTime.Now,
                Active = true
            };

            var userCreated = await _authRepository.Register(userToCreate, userToRegisterDTO.Password);

            UserToListDTO userToReturn = new (userCreated.Id, userCreated.Email, userCreated.Name, userCreated.Phone, "");

            return Ok(userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserToLoginDTO userToLoginDTO)
        {
            var userFromRepo = await _authRepository.Login(userToLoginDTO.Email.ToLower(), userToLoginDTO.Password);

            if (userFromRepo is null)
                return Unauthorized();

            var token = _tokenService.CreateToken(userFromRepo);

            UserToListDTO userToReturn = new (userFromRepo.Id, userFromRepo.Email, userFromRepo.Name, userFromRepo.Phone, token);

            return Ok(userToReturn);
        }
    }
}