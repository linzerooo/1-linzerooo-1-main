using Shared.Common;

namespace Shared.Requests.Candidates.GetCandidateFormById;

public class GetCandidateFormByIdResponse
{
    public List<string> Languages { get; set; } = [];
    
    public string ProfessionName { get; set; } = default!;
    
    public string PlaceAddress { get; set; } = default!;
    
    public string CandidateImagePath { get; set; } = default!;
    
    public Guid CandidateFormId { get; set; } = default!;

    public string CandidateEmail { get; set; } = default!;
    
    public string FullName { get; set; } = default!;

    public string Category { get; set; } = default!;

    public double Rating { get; set; } = default!;
    
    public Dictionary<string, string> SkillTypesAndSkills { get; set; } = [];
    
    public int Salary { get; set; } = 0;

    public string PhoneNumber { get; set; } = default!;

    public string AboutCandidate { get; set; } = default!;

    public List<ExperienceDto> Experiences { get; set; } = [];

    public int Age { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public string Level { get; set; } = default!;

    public int Views { get; set; } = default!;
    
    public Dictionary<string, string> SocialNetworksAndLinks { get; set; } = new();
    
    public List<string> Tags { get; set; } = [];
    
    public int ExperienceInYears { get; set; }
}