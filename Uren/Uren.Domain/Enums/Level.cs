using System.ComponentModel;

namespace Finate.Domain.Enums;

/// <summary>
/// Уровень
/// </summary>
public enum Level
{
    [Description("Intern")]
    Intern = 1,
    
    [Description("Junior")]
    Junior = 2,
    
    [Description("Strong Junior")]
    JuniorPlus = 3,
    
    [Description("Middle")]
    Middle = 4,
    
    [Description("Strong Middle")]
    MiddlePlus = 5,
    
    [Description("Senior")]
    Senior = 6
}