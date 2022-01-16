using System;
using Brainstorm.Business.Auth.Commands;
using Brainstorm.Business.Users.Commands;

namespace Brainstorm.API.Requests;

public static class UpdateUserRequestExtensions
{
    public static UpdateUserCommand ToCommand(this UpdateUserRequest request, Guid id)
    {
        return new UpdateUserCommand
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            ProfilePicture = request.ProfilePicture,
            Email = request.Email,
            Password = request.Password
        };
    }
}