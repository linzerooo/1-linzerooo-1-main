using System.ComponentModel.DataAnnotations;

namespace Shared.Requests.Auth.PostRegister;

/// <summary>
/// Заппрос на регистрацию
/// </summary>
public class PostRegisterRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">PostRegisterRequest</param>
    public PostRegisterRequest(PostRegisterRequest? request)
    {
        if (request is null) return;

        Role = request.Role;
        UserName = request.UserName;
        Email = request.Email;
        Password = request.Password;
        PasswordConfirm = request.PasswordConfirm;
    }   
    
    /// <summary>
    /// Пустой конструктор
    /// </summary>
    public PostRegisterRequest()
    {
    }
    
    /// <summary>
    /// Роль пользователя
    /// </summary>
    [Required]
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Почта
    /// </summary>
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Подтверждение пароля
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    [Compare(nameof(Password), ErrorMessage = "Passwords need to be equals")]
    public string PasswordConfirm { get; set; } = string.Empty;
}