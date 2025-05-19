using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostResetPasswordConfirm;

/// <summary>
/// Запрос на подтверждение сброса пароля
/// </summary>
public class PostResetPasswordConfirmRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">PostResetPasswordConfirmRequest</param>
    public PostResetPasswordConfirmRequest(PostResetPasswordConfirmRequest? request)
    {
        if (request is null) return;

        Email = request.Email;
        UserResetPasswordToken = request.UserResetPasswordToken;
        NewPassword = request.NewPassword;
        NewPasswordConfirm = request.NewPasswordConfirm;
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="email">Почта</param>
    /// <param name="userResetPasswordToken">Токен подтверждения сброса пароля</param>
    public PostResetPasswordConfirmRequest(string email, string userResetPasswordToken)
    {
        Email = email;
        UserResetPasswordToken = userResetPasswordToken;
    }

    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public PostResetPasswordConfirmRequest()
    {
    }
    
    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Токен подтверждения сброса пароля
    /// </summary>
    [Required]
    public string UserResetPasswordToken { get; set; } = default!;

    /// <summary>
    /// Новый пароль
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string NewPassword { get; set; } = default!;
    
    /// <summary>
    /// Подтверждение сброса пароля
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords need to be equals")]
    public string NewPasswordConfirm { get; set; } = default!;
}