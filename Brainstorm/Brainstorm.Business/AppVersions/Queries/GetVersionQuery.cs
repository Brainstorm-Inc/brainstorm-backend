using Brainstorm.Business.AppVersions.Responses;
using MediatR;

namespace Brainstorm.Business.AppVersions.Queries;

public class GetVersionQuery : IRequest<AppVersionCode>
{
}