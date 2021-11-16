using System;
using System.Data;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Queries;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Entities;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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
            var user = _ctx.Users
                .FirstOrDefault(u => request.Email == u.Email);

            if (user is null)
            {
                throw new Exception($"User with email address {request.Email} does not exist.");
            }

            var token = GenerateToken(request.Email, request.Password);

            var res = new LoginResponse {Token = token};
            return Task.FromResult(res);
        }

        private string GenerateToken(string email, string password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my very long secret key which should be longer than 128 bits, you idiot."));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Email, email),
                new("Date", DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                "brainstorm-inc",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}