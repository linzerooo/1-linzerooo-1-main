using MediatR;
using Shared.Requests.Candidates.GetCandidatesFormsByFilter;

namespace Finate.Application.Features.Queries.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterQuery(GetCandidatesFormsByFilterRequest request)
    : GetCandidatesFormsByFilterRequest(request),
        IRequest<GetCandidatesFormsByFilterResponse>;