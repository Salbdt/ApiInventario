using Inventory.Entities;

namespace Inventory.APIAuthorization.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}