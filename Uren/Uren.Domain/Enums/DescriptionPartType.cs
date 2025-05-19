using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Тип описания формы
/// </summary>
public enum DescriptionPartType
{
    [Description("Responsibilities")]
    Responsibilities = 1,
    
    [Description("Requirements")]
    Requirements = 2,
    
    [Description("Educational Requirements")]
    EducationalRequirements = 3,
    
    [Description("Working Hours")]
    WorkingHours = 4,
    
    [Description("Benefits")]
    Benefits = 5
}