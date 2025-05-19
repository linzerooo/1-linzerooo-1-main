using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
/// Опыт кандидата(Работа или учёба)
/// </summary>
public class Experience
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id формы кандидата
    /// </summary>
    public Guid CandidateFormId { get; set; }

    /// <summary>
    /// Форма кандидата
    /// </summary>
    public CandidateFormExtension CandidateFormExtension { get; set; } = default!;

    /// <summary>
    /// Название профессии/специальности
    /// </summary>
    public string ProfessionName { get; set; } = default!;
    
    /// <summary>
    /// Начало получения опыта
    /// </summary>
    public DateTime StartDate { get; set; }
    
    /// <summary>
    /// Окончание получения опыта
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Место
    /// </summary>
    public string PlaceName { get; set; } = default!;
    
    /// <summary>
    /// Об опыте
    /// </summary>
    public string? About { get; set; }
    
    /// <summary>
    /// Тип опыта
    /// </summary>
    public ExperienceType ExperienceType { get; set; }
}