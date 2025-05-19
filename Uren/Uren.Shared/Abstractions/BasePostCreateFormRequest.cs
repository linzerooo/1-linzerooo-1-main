using Finate.Domain.Enums;
using Shared.Common;

namespace Shared.Abstractions;

public class BasePostCreateFormRequest
{
    public BasePostCreateFormRequest()
    {
    }

    public BasePostCreateFormRequest(BasePostCreateFormRequest request)
    {
        if (request is null)
            return;

        ExperienceInYears = request.ExperienceInYears;
        ProfessionName = request.ProfessionName;
        Salary = request.Salary;
        Description = request.Description;
        Level = request.Level;
        Languages = request.Languages;
        Skills = request.Skills;
        PlaceAddress = request.PlaceAddress;
        Tags = request.Tags;
        Gender = request.Gender;
    }

    public int ExperienceInYears { get; set; }
    
    public string ProfessionName { get; set; }

    public string PlaceAddress { get; set; }
    
    public int Salary { get; set; }

    public string Description { get; set; }
    
    public Level Level { get; set; }
    
    public List<string> Languages { get; set; }
    
    public List<SkillDto> Skills { get; set; }
    
    public List<string> Tags { get; set; } 
    
    public Gender Gender { get; set; }
}