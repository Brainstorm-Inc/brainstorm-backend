using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Users.Commands;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Users.Handlers;

public class UpdateUserQueryHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly BrainstormContext _ctx;

    public UpdateUserQueryHandler(BrainstormContext ctx)
    {
        _ctx = ctx;
    }

    public Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!_ctx.Users.Any())
        {
            throw new Exception("No user found.");
        }

        var user = _ctx.Users
            .FirstOrDefault(u => u.Id == request.Id);

        user.Email = request.Email;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.ProfilePicture = request.ProfilePicture;
        user.Password = request.Password;
        _ctx.SaveChanges();

        var res = new UpdateUserResponse()
        {
            Id = request.Id,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            ProfilePicture = request.ProfilePicture,
        };
        
        return Task.FromResult(res);
    }
}