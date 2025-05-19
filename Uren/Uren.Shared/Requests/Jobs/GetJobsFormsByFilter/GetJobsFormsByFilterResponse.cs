using Shared.Abstractions;

namespace Shared.Requests.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterResponse : PaginationDto
{
    public List<GetJobsFormsByFilterResponseItem> JobsForms { get; set; } = [];

    public int TotalCount { get; set; } = 0;

    public string SearchValue { get; set; } = default!;
}