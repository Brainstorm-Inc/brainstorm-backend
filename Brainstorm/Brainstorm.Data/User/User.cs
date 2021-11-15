using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Dataflow;

namespace Brainstorm.Entities.User
{
    public class User : BaseEntity
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email {get; init; }
        public string ProfilePicture {get; init; }

         
        public User(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ProfilePicture = $"https://robohash.org/{FirstName}-{LastName}.png";
        }
    }
}