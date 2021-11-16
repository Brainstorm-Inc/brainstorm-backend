using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Commands;

namespace Brainstorm.API.Requests
{
    public static class SignupRequestExtentions
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