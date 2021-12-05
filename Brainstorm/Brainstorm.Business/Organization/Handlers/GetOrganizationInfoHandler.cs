using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Auth.Responses;
using Brainstorm.Business.Organization.Queries;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Business.Utils;
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

            var res = new GetOrganizationInfoResponse
            {
                Id = org.Id,
                Name = org.Name,
                Users = org.Users,
                Logo = org.LogoLink
            };
            return Task.FromResult(res);
        }
    }
}