using System;
using Brainstorm.Business.Users.Responses;
using MediatR;

namespace Brainstorm.Business.Users.Queries;

public class GetUserOrgsQuery : IRequest<OrgsDetails>
{
    public Guid UserId { get; init; }
}