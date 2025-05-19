namespace Finate.Domain.Entities;

/// <summary>
/// Тэги к анкете
/// </summary>
public class Tag
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя тэга
    /// </summary>
    public string TagName { get; set; } = default!;

    /// <summary>
    /// Список с формами с такими тэгами
    /// </summary>
    public List<Form> Forms { get; set; } = [];
}