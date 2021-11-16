using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace Brainstorm.Entities.User
{
    public class User : BaseEntity
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Salt { get; init; }
        public string ProfilePicture { get; init; }
    }
}