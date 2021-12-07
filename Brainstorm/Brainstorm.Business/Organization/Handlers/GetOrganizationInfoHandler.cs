using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using Brainstorm.Entities.User;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers
{
    public class GetOrganizationInfoHandler : IRequestHandler<GetOrganizationInfoQuery,GetOrganizationInfoResponse>
    {
        private readonly BrainstormContext _ctx;

        public GetOrganizationInfoHandler(BrainstormContext ctx)
        {
            _ctx = ctx;
        }
        
        public Task<GetOrganizationInfoResponse> Handle(GetOrganizationInfoQuery request, CancellationToken cancellationToken)
        {
            var org = _ctx.Organizations
                .FirstOrDefault(u => request.Id == u.Id);

            if (org is null)
            {
                throw new Exception($"Organization with ID {request.Id} does not exist");
            }

            var userList = org.Users;
            var userIdList = new List<Guid>();


            if (userList is not null)
            {
                userIdList = userList.Select(u => u.Id).ToList();
            }
            

            var res = new GetOrganizationInfoResponse
            {
                Id = org.Id,
                Name = org.Name,
                UserIds = userIdList,
                Logo = org.LogoLink
            };
            return Task.FromResult(res);
        }
    }
}