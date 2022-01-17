using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Brainstorm.Business.Organization.Commands;
using Brainstorm.Business.Organization.Responses;
using Brainstorm.Entities;
using MediatR;

namespace Brainstorm.Business.Organization.Handlers
{
    public class CreateOrganizationHandler : IRequestHandler<CreateOrganizationCommand, CreateOrganizationResponse>
    {
        private BrainstormContext _ctx;

        public CreateOrganizationHandler(BrainstormContext ctx)
        {
            _ctx = ctx;
        }
        
        
        public Task<CreateOrganizationResponse> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Id == request.CreatorId) ??
                       throw new Exception("User doesn't exist.");
            var alreadyExistingOrg = _ctx.Organizations.FirstOrDefault(u => u.Name == request.Name); 
            if (alreadyExistingOrg is not null)
            {
                throw new Exception($"Organization with name {request.Name} already exists.");
            }
            
            var org = request.ToOrganization();
            org.Users.Add(user);
            _ctx.Organizations.Add(org);
            _ctx.SaveChanges();

            var res = new CreateOrganizationResponse();
            return Task.FromResult(res);
        }
    }
}