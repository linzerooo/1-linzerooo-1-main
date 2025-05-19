namespace Shared.Common;

/// <summary>
/// Базовый ответ
/// </summary>
public abstract class ResponseBase
{
    /// <summary>
    /// Успешно ли
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// Коллекция с ошибками
    /// </summary>
    public List<ResponseErrorMessageItem> ErrorMessages { get; set; } = [];
}