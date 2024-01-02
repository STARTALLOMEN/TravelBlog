
using API.Data.Entities;

namespace API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}