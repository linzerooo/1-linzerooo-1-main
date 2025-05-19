namespace Shared.Requests.Jobs.GetJobsFormsByFilter;

public class GetJobsFormsByFilterResponseItem
{
    public string JobFormImagePath { get; set; } = default!;
    
    public Guid JobFormId { get; set; } = default!;

    public string CompanyName { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string JobName { get; set; } = default!;

    public string JobType { get; set; } = default!;
    
    public List<string> TopSkills { get; set; } = [];

    public double Rating { get; set; } = default!;

    public int Salary { get; set; } = 0;
}