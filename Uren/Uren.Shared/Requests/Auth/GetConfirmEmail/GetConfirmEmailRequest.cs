using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.GetConfirmEmail;

/// <summary>
/// Запрос на подтверждение почты
/// </summary>
public class GetConfirmEmailRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">GetConfirmEmailRequest</param>
    public GetConfirmEmailRequest(GetConfirmEmailRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
        UserConfirmEmailToken = request.UserConfirmEmailToken;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="email">Почта</param>
    /// <param name="userConfirmEmailToken">Токен подтверждения почты</param>
    public GetConfirmEmailRequest(string email, string userConfirmEmailToken)
    {
        Email = email;
        UserConfirmEmailToken = userConfirmEmailToken;
    }
    
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public GetConfirmEmailRequest()
    {
    }
    
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
    
    /// <summary>
    /// Токен подтверждения почты
    /// </summary>
    [Required]
    public string UserConfirmEmailToken { get; set; } = default!;
}