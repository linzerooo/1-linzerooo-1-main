namespace Shared.Requests.Candidates.GetCandidatesFormsByFilter;

public class GetCandidatesFormsByFilterResponseItem
{
    public string CandidateImagePath { get; set; } = default!;
    
    public Guid CandidateFormId { get; set; } = default!;
    
    public string FullName { get; set; } = default!;

    public string Category { get; set; } = default!;

    public double Rating { get; set; } = default!;

    public List<string> TopSkills = [];
}