using Shared.Common;

namespace Finate.Application.Interfaces;

/// <summary>
/// Валидатор для команд
/// </summary>
/// <typeparam name="TRequest">Команда для валидации</typeparam>
public interface IValidator<in TRequest>
{
    /// <summary>
    /// Функция валидации
    /// </summary>
    /// <param name="request">Команда для валидации</param>
    /// <returns>Список ошибок</returns>
    public List<ResponseErrorMessageItem> Validate(TRequest request);
}