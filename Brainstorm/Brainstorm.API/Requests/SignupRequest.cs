using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brainstorm.API.Requests
{
    public class SignupRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
