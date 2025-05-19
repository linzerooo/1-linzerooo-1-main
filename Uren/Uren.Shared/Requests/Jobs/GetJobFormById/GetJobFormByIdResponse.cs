namespace Shared.Requests.Jobs.GetJobFormById;

public class GetJobFormByIdResponse
{
    public string JobFormImagePath { get; set; } = default!;
    
    public Guid JobFormId { get; set; } = default!;

    public string CompanyName { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string JobName { get; set; } = default!;

    public string Category { get; set; } = default!;

    public DateTime CreatedDate { get; set; } = default!;

    public DateTime? ApplicationEnd { get; set; } = default!;

    public int ExperienceInYears { get; set; } = default!;

    public double Rating { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public string Level { get; set; } = default!;

    public int Applied { get; set; } = default!;

    public string JobType { get; set; } = default!;
    
    public int Salary { get; set; } = 0;

    public string PhoneNumber { get; set; } = default!;

    public string Description { get; set; } = default!;

    public List<string> Responsibilities { get; set; } = [];

    public List<string> WorkRequirements { get; set; } = [];

    public List<string> EducationalRequirements { get; set; } = [];

    public List<string> WorkingHours { get; set; } = [];

    public List<string> Benefits { get; set; } = [];

    public string Statement { get; set; } = default!;

    public List<string> Tags { get; set; } = [];
    
    public int Views { get; set; }

    public Dictionary<string, string> SocialNetworksAndLinks { get; set; } = new();
}