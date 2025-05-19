namespace Finate.Domain.Entities;

/// <summary>
/// Языки
/// </summary>
public class UserLanguage
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название языка
    /// </summary>
    public string Language { get; set; } = default!;

    /// <summary>
    /// Список с формами с такими языками
    /// </summary>
    public List<Form> Forms { get; set; } = [];
}