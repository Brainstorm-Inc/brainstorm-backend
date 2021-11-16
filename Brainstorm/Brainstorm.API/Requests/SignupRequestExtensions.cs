using Brainstorm.Business.Auth.Commands;

namespace Brainstorm.API.Requests
{
    public static class SignupRequestExtensions
    {
        public static SignupCommand ToCommand(this SignupRequest request)
        {
            return new SignupCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
        }
    }
}