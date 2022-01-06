using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Brainstorm.Business.Auth.Commands;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Business.Utils;
using Brainstorm.Entities;
using MediatR;
using System.Text;

namespace Brainstorm.Business.Auth.Handlers;

public class SignupHandler : IRequestHandler<SignupCommand, SignupResponse>
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

        var salt = GenerateSalt(32);
        var hashedPasswd = GenerateSaltedHash(request.Password, salt);
        request.Password = hashedPasswd;

        var user = request.ToUser(salt);
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

    private static string GenerateSalt(int size)
    {
        var buff = RandomNumberGenerator.GetBytes(size);

        return Convert.ToBase64String(buff);
    }

    private static string GenerateSaltedHash(string plainText, string salt)
    {
        var algorithm = SHA256.Create();

        var plainTextWithSaltBytes = plainText + salt;

        var hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainTextWithSaltBytes));

        return Convert.ToBase64String(hash);
    }
}
