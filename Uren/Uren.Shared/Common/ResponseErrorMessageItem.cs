namespace Shared.Common;

/// <summary>
/// Рекорд с полем реквеста и ошибкой
/// </summary>
/// <param name="PropertyName">Имя поля реквеста</param>
/// <param name="ErrorMessage">Сообщение ошибки</param>
public record ResponseErrorMessageItem(string PropertyName, string ErrorMessage);