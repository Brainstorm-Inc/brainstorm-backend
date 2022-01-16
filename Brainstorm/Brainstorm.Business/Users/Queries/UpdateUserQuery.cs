using System;
using Brainstorm.Business.Users.Responses;
using Brainstorm.Entities.User;
using MediatR;

namespace Brainstorm.Business.Users.Queries;

public class UpdateUserQuery : IRequest<UserDetails>
{
    public User user { get; init; }
}