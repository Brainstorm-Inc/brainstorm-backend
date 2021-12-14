using Brainstorm.Business.Auth.Queries;

namespace Brainstorm.API.Requests;

public static class LoginRequestExtensions
{
    public static LoginQuery ToQuery(this LoginRequest request)
    {
        return new LoginQuery
        {
            Email = request.Email,
            Password = request.Password
        };
    }
}