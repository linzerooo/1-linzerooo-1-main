using Finate.Domain.Enums;
using Shared.Abstractions;

namespace Shared.Requests.Jobs.PostCreateJobForm;

public class PostCreateJobFormRequest : BasePostCreateFormRequest
{
    public PostCreateJobFormRequest()
    {
    }
    
    public PostCreateJobFormRequest(PostCreateJobFormRequest request) : base(request)
    {
        Statement = request.Statement;
        JobType = request.JobType;
        ApplicationEndDate = request.ApplicationEndDate;
        Responsibilities = request.Responsibilities;
        WorkingHours = request.WorkingHours;
        WorkRequirements = request.WorkRequirements;
        EducationalRequirements = request.EducationalRequirements;
        Benefits = request.Benefits;
    }
    
    public string? Statement { get; set; }

    public JobType JobType { get; set; }

    public DateTime? ApplicationEndDate { get; set; }

    public List<string> Responsibilities { get; set; } = [];

    public List<string> WorkRequirements { get; set; } = [];

    public List<string> EducationalRequirements { get; set; } = [];

    public List<string> WorkingHours { get; set; } = [];

    public List<string> Benefits { get; set; } = [];
}