using System.Security.Claims;

namespace IMS.Web.API.Services
{
    public interface ITokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
