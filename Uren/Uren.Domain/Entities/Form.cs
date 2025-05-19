using Finate.Domain.Enums;

namespace Finate.Domain.Entities;

/// <summary>
/// Анкета юзера(Кандидата или работадателя)
/// </summary>
public class Form
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id пользователя
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; } = default!;

    /// <summary>
    /// Название профессии
    /// </summary>
    public string ProfessionName { get; set; } = default!;

    /// <summary>
    /// Место
    /// </summary>
    public string PlaceAddress { get; set; } = default!;
    
    /// <summary>
    /// Зарплата в USD
    /// </summary>
    public int Salary { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; set; }
    
    /// <summary>
    /// Уровень
    /// </summary>
    public Level? Level { get; set; }
    
    /// <summary>
    /// Рэйтинг
    /// </summary>
    public double Rating { get; set; }
    
    /// <summary>
    /// Заблокирован ли
    /// </summary>
    public bool IsBlocked { get; set; }
    
    /// <summary>
    /// Кол-во просмотров
    /// </summary>
    public int Views { get; set; }
    
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Языки
    /// </summary>
    public List<UserLanguage> Languages { get; set; } = [];

    /// <summary>
    /// Тэги
    /// </summary>
    public List<Tag> Tags { get; set; } = [];
    
    /// <summary>
    /// Навыки
    /// </summary>
    public List<Skill> Skills { get; set; } = [];
    
    /// <summary>
    /// Активна ли форма
    /// </summary>
    public bool IsActive { get; set; }
    
    /// <summary>
    /// Опыт
    /// </summary>
    public int ExperienceInYears { get; set; }
}