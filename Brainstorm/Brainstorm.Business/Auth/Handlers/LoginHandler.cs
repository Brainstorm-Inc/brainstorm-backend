using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Queries;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Auth.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly BrainstormContext _ctx;

        public LoginHandler(BrainstormContext ctx)
        {
            _ctx = ctx;
        }

        public Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var res = new LoginResponse();
            return Task.FromResult(res);
        }
    }
}