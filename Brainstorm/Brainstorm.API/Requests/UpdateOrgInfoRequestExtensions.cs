using System;
using System.Collections.Generic;
using Brainstorm.Entities.User;

namespace Brainstorm.API.Requests;

public static class UpdateOrgInfoRequestExtensions
{
    public static UpdateOrgInfoCommand ToCommand(this UpdateOrgInfoRequest request, string creatorId)
    {
        return new UpdateOrgInfoCommand
        {
            Name = request.Name,
            Users = new List<User>(),
            LogoLink = request.Logo,
            CreatorId =  new Guid(creatorId)
        };
    }
}