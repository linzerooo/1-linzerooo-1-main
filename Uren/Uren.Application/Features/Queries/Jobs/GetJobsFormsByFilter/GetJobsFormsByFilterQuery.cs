using MediatR;
using Shared.Requests.Jobs.GetJobsFormsByFilter;

namespace Finate.Application.Features.Queries.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterQuery(GetJobsFormsByFilterRequest request)
    : GetJobsFormsByFilterRequest(request),
    IRequest<GetJobsFormsByFilterResponse>;