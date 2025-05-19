using Shared.Abstractions;

namespace Shared.Requests.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterRequest : PaginationDto
{
    public GetCandidatesFormsByFilterRequest(GetCandidatesFormsByFilterRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        SearchValue = request.SearchValue;
        PageNumber = request.PageNumber;
        PageSize = request.PageNumber;
    }
    
    public GetCandidatesFormsByFilterRequest()
    {
    }
    
    public string? SearchValue { get; set; } = string.Empty;
}