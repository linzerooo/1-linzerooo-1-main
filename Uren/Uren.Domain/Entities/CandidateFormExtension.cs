namespace Finate.Domain.Entities;

/// <summary>
/// Расширение для сущности <see cref="CandidateForm"/> для кандидата
/// </summary>
public class CandidateFormExtension
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id формы
    /// </summary>
    public Guid CandidateFormId { get; set; }

    /// <summary>
    /// Форма кандидата
    /// </summary>
    public Form CandidateForm { get; set; } = default!;
    
    /// <summary>
    /// Закрыта ли форма
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Опыт кандидата
    /// </summary>
    public List<Experience> Experiences { get; set; } = [];
}