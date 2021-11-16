using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Commands;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Auth.Handlers
{
    class SignupHandler : IRequestHandler<SignupCommand, SignupResponse>
    {
        private BrainstormContext _ctx;

        public SignupHandler(BrainstormContext ctx)
        {
            _ctx = ctx;
        }

        public Task<SignupResponse> Handle(SignupCommand request, CancellationToken cancellationToken)
        {
            if (_ctx.Users.FirstOrDefault(u => u.Email == request.Email) is not null)
            {
                throw new Exception($"User with email {request.Email} already exists.");
            }

            var user = request.ToUser();

            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            var token = AuthUtils.GenerateToken(user.Email);
            var res = new SignupResponse
            {
                Id = user.Id,
                Email = request.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ProfilePicture = user.ProfilePicture,
                Token = token
            };
            return Task.FromResult(res);
        }
    }
}