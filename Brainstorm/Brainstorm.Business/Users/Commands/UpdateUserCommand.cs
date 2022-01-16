using System;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Business.Users.Responses;
using MediatR;

namespace Brainstorm.Business.Users.Commands;

public class UpdateUserCommand : IRequest<UpdateUserResponse>
{    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string ProfilePicture { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}