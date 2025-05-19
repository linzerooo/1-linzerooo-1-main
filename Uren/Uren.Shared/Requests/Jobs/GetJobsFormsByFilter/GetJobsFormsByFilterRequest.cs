using Shared.Abstractions;

namespace Shared.Requests.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterRequest : PaginationDto
{
    public GetJobsFormsByFilterRequest(GetJobsFormsByFilterRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        
        SearchValue = request.SearchValue;
        PageNumber = request.PageNumber;
        PageSize = request.PageNumber;
    }
    
    public GetJobsFormsByFilterRequest()
    {
    }
    
    public string? SearchValue { get; set; } = string.Empty;
}