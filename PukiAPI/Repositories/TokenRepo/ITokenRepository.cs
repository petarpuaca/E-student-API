using Microsoft.AspNetCore.Identity;

namespace PukiAPI.Repositories.TokenRepo
{
    public interface ITokenRepository
    {
    string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
