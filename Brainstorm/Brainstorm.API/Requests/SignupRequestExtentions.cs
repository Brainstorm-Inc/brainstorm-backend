using Brainstorm.Business.Auth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainstorm.API.Requests
{
    public static class SignupRequestExtentions
    {

        public static SignupCommand ToCommand(this SignupRequest request)
        {
            return new SignupCommand {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
        }
    }
}
