using Microsoft.AspNetCore.Identity;

namespace BlazorCourse.Api.Helper
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}
