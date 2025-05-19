using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
/// Навыки указанные в анкете
/// </summary>
public class Skill
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Формы с таким скилом
    /// </summary>
    public List<Form> Forms { get; set; } = [];
    
    /// <summary>
    /// Тип скила
    /// </summary>
    public SkillType SkillType { get; set; }
    
    /// <summary>
    /// Самый главный ли
    /// </summary>
    public bool IsTopSkill { get; set; }

    /// <summary>
    /// Название скилла
    /// </summary>
    public string SkillName { get; set; } = default!;
}