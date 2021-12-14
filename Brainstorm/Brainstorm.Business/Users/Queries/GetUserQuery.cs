using System;
using Brainstorm.Business.Users.Responses;
using MediatR;

namespace Brainstorm.Business.Users.Queries
{
    public class GetUserQuery : IRequest<UserDetails>
    {
        public Guid UserId { get; init; }
    }
}
