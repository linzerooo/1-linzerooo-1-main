using Finate.Domain.Enums;

namespace Shared.Common;

public class SkillDto
{
    public SkillType Type { get; set; }

    public string Name { get; set; }
    
    public bool IsTopSkill { get; set; }
}