using MediatR;
using Shared.Requests.Candidates.GetCandidateFormById;

namespace Finate.Application.Features.Queries.Candidates.GetCandidateFormById;

public class GetCandidateFormByIdQuery(Guid candidateFormId) : IRequest<GetCandidateFormByIdResponse>
{
    public Guid CandidateFormId { get; set; } = candidateFormId;
}