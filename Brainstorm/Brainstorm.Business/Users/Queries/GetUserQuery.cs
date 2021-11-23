using System;
using Brainstorm.Business.Users.Responses;
using MediatR;

namespace Brainstorm.Business.Users.Queries
{
    public class GetUserQuery : IRequest<UserCode>
    {
        public Guid UserId { get; init; }
    }
}
