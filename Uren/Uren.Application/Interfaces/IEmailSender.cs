namespace Finate.Application.Interfaces;

/// <summary>
/// Отвечает за отправку сообщений по почте
/// </summary>
public interface IEmailSender
{
    /// <summary>
    /// Отправляет письмо на почту
    /// </summary>
    /// <param name="to">Почтовый адрес, кому надо отправить письмо</param>
    /// <param name="message">Текст письма</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task</returns>
    public Task SendEmailAsync(string to, string message, CancellationToken cancellationToken);
}