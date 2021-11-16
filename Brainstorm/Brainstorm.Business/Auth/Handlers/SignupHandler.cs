using Brainstorm.Business.Auth.Commands;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Entities;
using Brainstorm.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brainstorm.Business.Auth.Handlers
{
    class SignupHandler : IRequestHandler<SignupCommand, SignupResponse>
    {
        private readonly BrainstormContext _ctx;
        public SignupHandler(BrainstormContext ctx)
        {
            _ctx = ctx;
        }

        public Task<SignupResponse> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            var exists = _ctx.Users.Where(u => u.Email == request.Email).Any(); 
            if (exists)
            {
                throw new Exception($"User with email {request.Email} already exists.");
            }

            var user = new User { 
                FirstName = request.FirstName, 
                LastName = request.LastName, 
                Email = request.Email,
                ProfilePicture = $"https://robohash.org/{request.FirstName}-{request.LastName}.png"
            };
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return Task.FromResult(new SignupResponse());
        }
    }
}