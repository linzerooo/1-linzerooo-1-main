using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Тип скилла
/// </summary>
public enum SkillType
{
    [Description("Soft Skill")]
    SoftSkill = 1,
    
    [Description("Hard Skill")]
    HardSkill = 2
}