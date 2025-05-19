using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
///  Расширение для сущности <see cref="Form"/> для работодателя
/// </summary>
public class JobFormExtension
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id формы
    /// </summary>
    public Guid FormId { get; set; }

    /// <summary>
    /// Форма
    /// </summary>
    public Form JobForm { get; set; } = default!;
    
    /// <summary>
    /// Лозунг
    /// </summary>
    public string? Statement { get; set; }
    
    /// <summary>
    /// Тип работы по времени
    /// </summary>
    public JobType JobType { get; set; }
    
    /// <summary>
    /// Кол-во откликнувшихся
    /// </summary>
    public int Applied { get; set; }
    
    /// <summary>
    /// Дата окончания приёма заявок
    /// </summary>
    public DateTime? ApplicationEndDate { get; set; }

    /// <summary>
    /// Список описаний
    /// </summary>
    public List<JobFormDescriptionPart> DescriptionParts { get; set; } = [];
}