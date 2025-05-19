using Shared.Abstractions;

namespace Shared.Requests.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterResponse : PaginationDto
{
    public List<GetCandidatesFormsByFilterResponseItem> CandidatesForms = [];

    public int TotalCount { get; set; } = 0;

    public string SearchValue { get; set; } = default!;
}