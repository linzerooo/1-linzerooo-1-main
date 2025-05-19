using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostResetPassword;

/// <summary>
/// Запрос на сброс пароля
/// </summary>
public class PostResetPasswordRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">PostResetPasswordRequest</param>
    public PostResetPasswordRequest(PostResetPasswordRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
    }
    
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public PostResetPasswordRequest()
    {
    }
    
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
}