using DatingApi.Models;

namespace DatingApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
