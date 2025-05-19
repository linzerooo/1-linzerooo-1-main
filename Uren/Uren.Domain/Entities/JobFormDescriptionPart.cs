using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
/// Часть описания анкеты работадателя <see cref="JobFormExtension"/>
/// </summary>
public class JobFormDescriptionPart
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id формы работадателя
    /// </summary>
    public Guid JobFormId { get; set; }

    /// <summary>
    /// Форма работадателя
    /// </summary>
    public JobFormExtension JobForm { get; set; } = default!;
    
    /// <summary>
    /// Тип описания
    /// </summary>
    public DescriptionPartType DescriptionPartType { get; set; }

    /// <summary>
    /// Текст описания
    /// </summary>
    public string Content { get; set; } = default!;
}