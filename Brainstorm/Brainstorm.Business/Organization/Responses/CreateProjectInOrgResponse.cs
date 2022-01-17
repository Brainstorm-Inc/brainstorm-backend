using System;
using System.Collections.Generic;
using Brainstorm.Entities.Topic;

namespace Brainstorm.Business.Organization.Responses;

public class CreateProjectInOrgResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid OrgId { get; set; }
    public List<Topic> Topics { get; set; }
}