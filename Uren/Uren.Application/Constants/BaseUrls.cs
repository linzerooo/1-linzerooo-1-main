namespace Finate.Application.Constants;

/// <summary>
/// Базовые адреса для Email писем
/// </summary>
public static class BaseUrls
{
    /// <summary>
    /// Ссылка на подтверждение почты
    /// </summary>
    /// <param name="confirmToken">Токен подтверждения почты</param>
    /// <param name="email">Email адрес пользователя</param>
    /// <returns>Ссылка на подтверждение почты</returns>
    public static string ConfirmEmailLink(string confirmToken, string email)
        => $"https://localhost:44383/Auth/ConfirmEmail?confirmToken={confirmToken}&email={email}";
    
    /// <summary>
    /// Ссылка на подтверждение сброса пароля
    /// </summary>
    /// <param name="confirmToken">Токен подтверждения сброса пароля</param>
    /// <param name="email">Email адрес пользвателя</param>
    /// <returns>Ссылка на подтверждение сброса пароля</returns>
    public static string ConfirmPasswordResetLink(string confirmToken, string email)
        => $"https://localhost:44383/Auth/ResetPasswordConfirm?confirmToken={confirmToken}&email={email}";
}